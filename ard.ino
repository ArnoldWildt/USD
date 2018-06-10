#include <LinkedList.h>

String detect = "A";                                                    //String Variable "detect" mit Wert: "A"
char detbuff [500];                                                     //Char Array mit 500 "Plätzen".

String inputString;                                                     //String Variable "inputString
char inputchars[500];                                                   //Char Array mit 500 "Plätzen". Aus den verschiedenen "Chars" Plural wird ein einzelner String Singular.
                                                                        //String <- ist in der Arduino Library eine eigene Klasse, die es sonst nicht in C++ gibt? (selber nicht sicher). Die anderen Sachen wie int, etc. sind in C++ eingebunden.
boolean stringComplete = false;                                         //boolean Variable "stringComplete" mit Wert: "false"
boolean ready_test = false;                                             //boolean Variable "ready_test" mit Wert: "false"
boolean ontime_done = false;                                            //boolean Variable "onetime_done" mit Wert: "false"
boolean pause = false;                                                  //boolean Variable "pause" mit Wert: "false"
int count;                                                              //int Variable "count"

unsigned long diff_ontime;                                              //unsigned long Variable "diff_ontime"
unsigned long diff_offtime;                                             //unsigned long Variable "diff_offtime"

LinkedList<unsigned long> ontime = LinkedList<unsigned long>();        //Linkedlists sind ähnlich wie Arrays diese können aber wachsen nicht wie normale Arrays. https://en.wikipedia.org/wiki/Linked_list
LinkedList<unsigned long> offtime = LinkedList<unsigned long>();       //Wir erstellen Linkedlists mit unsigned long werten. 
LinkedList<unsigned long> number = LinkedList<unsigned long>();


String slice() {                                                       //Richtig diese gibt aber einen String zurück deswegen String slice(); siehe return sliced; in der letzten Zeile der Funktion.
  int index = inputString.indexOf(";");                                //Wir nehmen den inputString der gefüllt ist mit den Befehlen von dem PC 
                                                                        // Beispiel: L150;50;10;EOL;50;30;10;EOT;
  String sliced = inputString.substring(0, index);                      // Das L wird weiter unten schon entfernt somit haben wir nurnoch 150;50;10;EOL;50;30;10;EOT;. Nun wird nach dem char ; in dem String gesucht (inputString.indexOf(";"))(der erste wird immer nur ausgegeben.) 
  inputString = inputString.substring(index + 1);                       // die position des chars (;) wird dann in int index gespeichert. 150;50;10;EOL;50;30;10;EOT;
                                                                        // der erste ; ist in 3 nun wird ein neuer String erstellt indem wir nur einen Teil des String benutzen inputString.substring(0, index); von 0 bis zu index unserem char ; wir erhalten 150 als neuen String
  return sliced;                                                        // Nun wird der Teil gelöscht den wir benutz haben indem wir einen neuen substring erstellen und einfach den Part skippen den wir benutz haben index + 1. 
                                                                        // Zuletzt können wir den string sliced zurück geben.
}

void work()  {                                                        //Funktion "work"

  ready_test = false;                                                 //Variable "ready_test" Wert: "false" befor diese Funktion ausgeführt wird steht ein if statement, welches true ist wenn ready_test true ist. Deswegen müssen wir es wieder false setzen damit diese Funktion nicht immer wieder ausgeführt wird.
  count = ontime.size();                                              //Variable "count" bekommt den Wert von der Funktion ontime.size() .size() bei dieser Library ist die Funktion die anzahl der Elemente in der Liste raus zu bekommen. Diese wird dann heruntergezählt, bis alle Elemente in der Liste abgearbeitet sind. 
  while (true) {                                                      //Endlosschleife Beginn
    if (count ==	0) {                                          // Wenn die Variable "count" den Wert: "0" hat werden die Variablen sicherheitshalber, damit sich da doch nicht noch ein wert versteckt. 
      ontime.clear();
      offtime.clear();
      number.clear();
      return;

    }
    int ontime_current = ontime.get(0);                              //int Variable "ontime_current" mit Wert: aus den ersten Werten aus den Listen, diese werden anschließend ausgeführt deswegen current.
    int offtime_current = offtime.get(0);                            //momentaner Wert oder wie? richtig
    int number_amount = number.get(0);

    for (int i = 0; i < number_amount; i++) {                        //hier werden die eingegebenen Perioden quasi nacheinander ausgeführt oder? genau!
      unsigned long current_time = millis();

      unsigned long ontime_millis = current_time + ontime_current;    //Wir lesen den Timer aus dem Arduino aus. (millis()) dieser timer zählt hoch. Um dann das Relais auszuschalten müssen wir es dann dazu addieren damit wir wissen wann der Arduino abschlaten muss.Beispiel: Current Arduino Time 20ms Testlauf ontime = 1000ms . Also müssen wir abschalten wenn der Arduino 1020ms erreicht hat.
      unsigned long offtime_millis = ontime_millis + offtime_current; 

      digitalWrite(13, HIGH);                                         // Relais an !
      digitalWrite(12, HIGH);
      digitalWrite(11, HIGH);
      digitalWrite(10, HIGH);

      while (true) {


        if (millis() >= ontime_millis && !ontime_done && !pause) {    //wenn derzeitige Arduino Zeit (millis()) größer gleich is Schalte aus. Plus nicht ontime_done plus nicht pause.
          ontime_done = true;                                         //Variable "ontime_done" bekommt Wert: "true"
          digitalWrite(13, LOW);                                      // Rleais Aus!
          digitalWrite(12, LOW);
          digitalWrite(11, LOW);
          digitalWrite(10, LOW);
        }
        if (millis() >= offtime_millis && !pause) {                   //Break -> unterbrich die derzeit ausgeführte schleife in dem fall while (true) Zeile 60.
          break;
        }

        if (!digitalRead(6)) {                                        //Genau wenn gedrückt wird mach aus.
          digitalWrite(13, LOW);                                      // Rleais Aus!
          digitalWrite(12, LOW);
          digitalWrite(11, LOW);
          digitalWrite(10, LOW);
          
          ontime.clear();                                            //Richtig
          offtime.clear();
          number.clear();
          return;
          Serial.println("Reset button");
          
        }

        serialEvent();                                              //Funktion fängt ab Zeile 217 an. Wenn der Arduino Seriele Daten bekommt. Speicher die einzelnen Chars in ein String. -> inputString.                    

        if (stringComplete) {                                      //Das Interface schickt diese drei Buchstaben an den Arduino wenn Pause / Stop / Weiter gedrückt wird. -> P = Pause, S = Stop, W = Weiter sind alle selbst definiert. Er schaut dann was er bekommen hat mit inputString.startsWith("P") beispielsweise.
          if (inputString.startsWith("P")) {
            digitalWrite(13, LOW);                                 // Relais aus
            digitalWrite(12, LOW);
            digitalWrite(11, LOW);
            digitalWrite(10, LOW);
            pause = true;                                          // damit nichts mehr ausgeführt wird.
            current_time = millis();
            diff_ontime = ontime_millis - current_time;           // die differenz die noch zu laufen ist. ist glaub falsch berechnet muss da nochmal drüber schauen. 
            diff_offtime = offtime_millis - current_time;

          }

          if (inputString.startsWith("S")) {
            digitalWrite(13, LOW);                                //Relais aus
            digitalWrite(12, LOW);
            digitalWrite(11, LOW);
            digitalWrite(10, LOW);
            ontime.clear();
            offtime.clear();
            number.clear();
            return;

          }

          if (inputString.startsWith("W")) {
            pause = false;
            digitalWrite(13, HIGH);                                //Relais an
            digitalWrite(12, HIGH);
            digitalWrite(11, HIGH);
            digitalWrite(10, HIGH);
            current_time = millis();
            ontime_millis = diff_ontime + current_time;
            offtime_millis = diff_offtime + current_time;
          }

          stringComplete = false;
          inputString = "";
        }

      }

      ontime_done = false;
    }
    ontime.remove(0);
    offtime.remove(0);
    number.remove(0);
    count--;

  }
}

void setup()  {
  Serial.begin(115200);

  pinMode(13, OUTPUT);                                                 // Relais
  pinMode(12, OUTPUT);                                                 // Relais
  pinMode(11, OUTPUT);                                                 // Relais
  pinMode(10, OUTPUT);                                                 // Relais

  pinMode(5, INPUT_PULLUP);                                           // Stop Test ??? Jop
  pinMode(6, OUTPUT);                                                 // Laborbuchse 5V ja
  pinMode(7, OUTPUT);                                                 // 5V für den Resettaster


  digitalWrite(6, HIGH);
  digitalWrite(7, HIGH);
  digitalWrite(13, LOW);
  digitalWrite(12, LOW);
  digitalWrite(11, LOW);
  digitalWrite(10, LOW);

}

void loop() {                                                          //ab 217 ist es eine neue Funktion. die das SerieleSignal einließt und abspeichert unter inputString.

  if (stringComplete) {
    detect.toCharArray(detbuff, 20);  // ist glaub unnötig muss ich nochmal schauen.

    if (inputString.startsWith("A")) {    // hier wird auch wieder nach dem ersten Buchstaben geschaut die von dem Interface kommen.
      Serial.print("Arduino");

    }

    if (inputString.startsWith("L")) {
      inputString.remove(0, 1);                                       // Remove first Char in String. -> L
      while (true) {

        ontime.add(slice().toInt());  // Slice funktion die einen String zurück gibt und in der Linkedlist abgespeichert wird. .toInt() -> string to int.
        offtime.add(slice().toInt());
        number.add(slice().toInt());

        String buffer_str = slice(); // Auslesen von EOT oder EOL wenn nichts der beiden kommt = Error = Abbrechen

        if (buffer_str == "EOT") {
          ready_test = true;
          Serial.println("Read successfull!");
          break;

        }

        else if (buffer_str != "EOL") {
          Serial.print("Error");
          Serial.println(inputString);
          ontime.clear();
          offtime.clear();
          number.clear();

          break;

        }
      }
    }
    stringComplete = false;
    inputString = "";

  }
  if (ready_test) { // wird gesetzt, wenn der das SerieleSignal ausgelesen hat und ein EOT am ende bekommen hat. 
    work();

  }
  serialEvent();

}



void serialEvent() {
  int i = 0; // debug
  while (Serial.available()) // selbst erklärend
  {
    char inChar = (char)Serial.read();  // lesen des Serielen eingangs und abspeicher in char

    inputString += inChar; // char zu dem String "addieren"
    i++; //debug
    Serial.println(i); // // debug

  }
  stringComplete = true; // wenn nichts mehr kommt = stringComplete = true.
  Serial.print(inputString); // debug

}
