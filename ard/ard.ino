#include <LinkedList.h>

String detect = "A";
char detbuff [500];

String inputString;
char inputchars[500];

boolean stringComplete = false;
boolean ready_test = false;
boolean ontime_done = false;
boolean pause = false;
int count;

unsigned long diff_ontime;
unsigned long diff_offtime;

LinkedList<unsigned long> ontime = LinkedList<unsigned long>();
LinkedList<unsigned long> offtime = LinkedList<unsigned long>();
LinkedList<unsigned long> number = LinkedList<unsigned long>();


String slice() {
  int index = inputString.indexOf(";");

  String sliced = inputString.substring(0, index);
  inputString = inputString.substring(index + 1);

  return sliced;

}

void work()  {

  ready_test = false;
  count = ontime.size();
  while (true) {
    if (count ==	0) {
      ontime.clear();
      offtime.clear();
      number.clear();
      return;

    }
    int ontime_current = ontime.get(0);
    int offtime_current = offtime.get(0);
    int number_amount = number.get(0);

    for (int i = 0; i < number_amount; i++) {
      unsigned long current_time = millis();

      unsigned long ontime_millis = current_time + ontime_current;
      unsigned long offtime_millis = ontime_millis + offtime_current;

      digitalWrite(13, HIGH); // Relais an !
      digitalWrite(12, HIGH);
      digitalWrite(11, HIGH);
      digitalWrite(10, HIGH);

      while (true) {


        if (millis() >= ontime_millis && !ontime_done && !pause) {
          ontime_done = true;
          digitalWrite(13, LOW); // Rleais Aus!
          digitalWrite(12, LOW);
          digitalWrite(11, LOW);
          digitalWrite(10, LOW);
        }
        if (millis() >= offtime_millis && !pause) {
          break;
        }

        if (!digitalRead(5)) {
          digitalWrite(13, LOW); // Rleais Aus!
          digitalWrite(12, LOW);
          digitalWrite(11, LOW);
          digitalWrite(10, LOW);
          
          ontime.clear();
          offtime.clear();
          number.clear();
          Serial.println("Reset button");
          return;
          
          
        }

        serialEvent();

        if (stringComplete) {
          if (inputString.startsWith("P")) {
            digitalWrite(13, LOW); // Relais aus
            digitalWrite(12, LOW);
            digitalWrite(11, LOW);
            digitalWrite(10, LOW);
            pause = true;
            current_time = millis();
            diff_ontime = ontime_millis - current_time;
            diff_offtime = offtime_millis - current_time;

          }

          if (inputString.startsWith("S")) {
            digitalWrite(13, LOW);
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
            digitalWrite(13, HIGH);
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

  pinMode(13, OUTPUT); // Relais
  pinMode(12, OUTPUT); // Relais
  pinMode(11, OUTPUT); // Relais
  pinMode(10, OUTPUT); // Relais

  pinMode(5, INPUT_PULLUP); // Stop Test ???
  pinMode(6, OUTPUT); // Labor buchse
  pinMode(7, OUTPUT); // 5V


  digitalWrite(6, HIGH);
  digitalWrite(7, HIGH);
  digitalWrite(13, LOW);
  digitalWrite(12, LOW);
  digitalWrite(11, LOW);
  digitalWrite(10, LOW);

}

void loop() {

  if (stringComplete) {
    detect.toCharArray(detbuff, 20);

    if (inputString.startsWith("A")) {
      Serial.print("Arduino");

    }

    if (inputString.startsWith("L")) {
      inputString.remove(0, 1); // Remove first Char in String. -> L
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
