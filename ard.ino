#include <LinkedList.h>

String detect = "A";                                                    //String Variable "detect" mit Wert: "A"
char detbuff [500];                                                     //char Variable "detbuff" was bedeutet aber [500]? warum nicht "=500"? char hat ein byte oder?

String inputString;                                                     //String Variable "inputString
char inputchars[500];                                                   //char Variable inputchars gleiche Frage wie in Zeile 4 und warum inputchars im Plural und inputString im Singular
                                                                        //Zwischenfrage: warum wird beim Arduino eigentlich String großgeschrieben und char, int und boolean kleingeschrieben? hat das einen tieferen Sinn?
boolean stringComplete = false;                                         //boolean Variable "stringComplete" mit Wert: "false"
boolean ready_test = false;                                             //boolean Variable "ready_test" mit Wert: "false"
boolean ontime_done = false;                                            //boolean Variable "onetime_done" mit Wert: "false"
boolean pause = false;                                                  //boolean Variable "pause" mit Wert: "false"
int count;                                                              //int Variable "count"

unsigned long diff_ontime;                                              //unsigned long Variable "diff_ontime"
unsigned long diff_offtime;                                             //unsigned long Variable "diff_offtime"

LinkedList<unsigned long> ontime = LinkedList<unsigned long>();        //LinkedList bezieht sich auf die Virtuelle Befehlsliste im Interface oder? D.h. hier wird der Übertragende Wert in eine Variable geschrieben oder?
LinkedList<unsigned long> offtime = LinkedList<unsigned long>();       //Was hat es mit diesen drei Zeilen auf sich? 18-20
LinkedList<unsigned long> number = LinkedList<unsigned long>();


String slice() {                                                       //Das ist eine Funktion und keine Variable oder?
  int index = inputString.indexOf(";");                                //Die Zeilen 23-29 bitte erklären!

  String sliced = inputString.substring(0, index);
  inputString = inputString.substring(index + 1);

  return sliced;

}

void work()  {                                                        //Funktion "work"

  ready_test = false;                                                 //Variable "ready_test" Wert: "false"  warum muss nochmals der Wert: "false" zugewiesen werden? siehe Zeile 10
  count = ontime.size();                                              //Variable "count" bekommt den Wert von der Funktion ontime.size() kannst du dazu noch etwas erklären
  while (true) {                                                      //Endlosschleife Beginn
    if (count ==	0) {                                          // Wenn die Variable "count" den Wert: "0" hat werden die Variablen "ontime", "offtime" und "number" gelöscht?
      ontime.clear();
      offtime.clear();
      number.clear();
      return;

    }
    int ontime_current = ontime.get(0);                              //int Variable "ontime_current" mit Wert: "?". Aus ontime? kannst die Zeilen 45-47 erklären? current ist hier als Adjektiv zu verstehen oder also in dt. als "aktuell" o. "gegenwärtig"
    int offtime_current = offtime.get(0);                            //momentaner Wert oder wie?
    int number_amount = number.get(0);

    for (int i = 0; i < number_amount; i++) {                        //hier werden die eingegebenen Perioden quasi nacheinander ausgeführt oder?
      unsigned long current_time = millis();

      unsigned long ontime_millis = current_time + ontime_current;    //Ich verstehe nicht ganz warum addiert und nicht subrahiert wird die verbliebene Zeit wird doch kleiner oder? Habe ich einen falschen Denkansatz
      unsigned long offtime_millis = ontime_millis + offtime_current;

      digitalWrite(13, HIGH);                                         // Relais an !
      digitalWrite(12, HIGH);
      digitalWrite(11, HIGH);
      digitalWrite(10, HIGH);

      while (true) {


        if (millis() >= ontime_millis && !ontime_done && !pause) {    //Nachdem die Einschaltzeit durch ist kommt hier die Ausschaltzeit oder? Was bedeutet hier das >= es steht je keine Variable davor
          ontime_done = true;                                         //Variable "ontime_done" bekommt Wert: "true"
          digitalWrite(13, LOW);                                      // Rleais Aus!
          digitalWrite(12, LOW);
          digitalWrite(11, LOW);
          digitalWrite(10, LOW);
        }
        if (millis() >= offtime_millis && !pause) {                   //Erkläre was hier abgefragt wird, sodass der break ausgeführt wird
          break;
        }

        if (!digitalRead(6)) {                                        //Potentalfreier Schalt = 5V? dann alle Relais aus! oder?
          digitalWrite(13, LOW);                                      // Rleais Aus!
          digitalWrite(12, LOW);
          digitalWrite(11, LOW);
          digitalWrite(10, LOW);
          
          ontime.clear();                                            //Eingabewerte von ontime, offtime und number werden wieder gelöscht  oder?
          offtime.clear();
          number.clear();
          return;
          Serial.println("Reset button");
          
        }

        serialEvent();                                              //Was ist ein seialEvent? Wenn in der Schleife noch serielle Daten komme werden diese zu einem vorhandenem String addiert? kannst du das Erklären?                        

        if (stringComplete) {                                      //Kannst du von Zeile 90-137 erkläre hier geht es doch umd die betätigung der Buttons Start/Stop und Pause oder? Warum startet der string mit "P"(=Pause?),"S"(=Stop?)und "W"(=Work?)
          if (inputString.startsWith("P")) {
            digitalWrite(13, LOW);                                 // Relais aus
            digitalWrite(12, LOW);
            digitalWrite(11, LOW);
            digitalWrite(10, LOW);
            pause = true;
            current_time = millis();
            diff_ontime = ontime_millis - current_time;
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

void loop() {                                                          //Ok Zeile 164-231 Raff ich auch nicht ganz, da habe ich definitiv noch Klärungsbedarf.... hier geht es doch um die Kommunikation von Interface und Arduino oder?

  if (stringComplete) {
    detect.toCharArray(detbuff, 20);

    if (inputString.startsWith("A")) {
      Serial.print("Arduino");

    }

    if (inputString.startsWith("L")) {
      inputString.remove(0, 1);                                       // Remove first Char in String. -> L
      while (true) {

        ontime.add(slice().toInt());
        offtime.add(slice().toInt());
        number.add(slice().toInt());

        String buffer_str = slice();

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
  if (ready_test) {
    work();

  }
  serialEvent();

}



void serialEvent() {
  int i = 0; // debug
  while (Serial.available())
  {
    char inChar = (char)Serial.read();

    inputString += inChar;
    i++; //debug
    Serial.println(i); // // debug

  }
  stringComplete = true;
  Serial.print(inputString);

}
