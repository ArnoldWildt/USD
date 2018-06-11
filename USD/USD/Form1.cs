using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.IO.Ports;
using System.Threading;

namespace USD
{
    public partial class usd_form : Form
    {

        SerialPort SP = new SerialPort();
        public string arduino_port;

        Dictionary<string, int> converion = new Dictionary<string, int>();

        List<int> ontime_list = new List<int>();
        List<int> offtime_list = new List<int>();
        List<int> number_list = new List<int>();
        List<string> ontimeunit_list = new List<string>();
        List<string> offtimeunit_list = new List<string>();

        int ontime;
        int offtime;
        int number;

        bool error = false;
        bool started = false;
        bool paused = false;
        bool connected = false;
        object listbox_item;
        int listbox_index;

        string line;

        string file_string;
        
        string delimiter = ";";

        int all_time_h;
        int all_time_min;
        int all_time_sec;
        int all_time_sum;

        public usd_form()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cbo_ontime.SelectedIndex = 0;
            cbo_offtime.SelectedIndex = 0;

            converion.Add("ms", 1);
            converion.Add("s", 1000);
            converion.Add("min", 60000);
            converion.Add("h", 3600000);

            txt_ontime.AutoSize = false;
            txt_offtime.AutoSize = false;
            txt_number.AutoSize = false;

            this.txt_ontime.Size = new System.Drawing.Size(129, 21);
            this.txt_offtime.Size = new System.Drawing.Size(129, 21);
            this.txt_number.Size = new System.Drawing.Size(129, 21);

            label1.Parent = background;
            label2.Parent = background;
            label3.Parent = background;
            lbl_arduino_connected.Parent = background;
            btn_eingabe.Parent = background;
            btn_start_stop.Parent = background;
            btn_pause.Parent = background;

            SP.BaudRate = 115200;
            SP.DataBits = 8;
            SP.StopBits = StopBits.One;
            SP.Handshake = Handshake.None;
            SP.Parity = Parity.None;

            SP.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);

            findarduino();

        }

        public void findarduino()
        {
            string[] ports = SerialPort.GetPortNames();

            foreach (string port in ports)
            {
                SP.PortName = port;

                Console.WriteLine(port);

                try
                {
                    SP.Open();
                }
                catch
                {
                    continue;
                }
                

                SP.Write("A");

                Thread.Sleep(150);

                SP.Close();

            }

            if (arduino_port == null) // "" / null
            {
                connect_timer.Start();
            }
            else
            {
                SP.PortName = arduino_port;
                SP.Open();
                lbl_arduino_connected.Text = "Arduino on Port: " + arduino_port;
                connected = true;
                connect_timer.Stop();
            }

        }

        public void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {

            SerialPort sp = (SerialPort)sender;

            string indata = sp.ReadExisting();
            string port = SP.PortName;

            Console.WriteLine(indata);
            Console.WriteLine(indata.Length);

            if (indata.Contains("Arduino"))
            {
                arduino_port = port;
            }
            if (indata.Contains("Error"))
            {
                error = true;
                MessageBox.Show("Arduino Fehler!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (indata.Contains("Reset"))
            {
                error = true;
                MessageBox.Show("Reset Knopf betätigt!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public void btn_eingabe_Click(object sender, EventArgs e)
        {
           
            try{
                ontime = Int32.Parse(txt_ontime.Text);
                offtime = Int32.Parse(txt_offtime.Text);
                number = Int32.Parse(txt_number.Text);
            }
            catch(FormatException)
            {
                MessageBox.Show("Fehler in den Textboxen bitte überprüfen!", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (connected)
            {
                btn_start_stop.Enabled = true;
            }

            string timeunit_ontime = cbo_ontime.Text;
            string timeunit_offtime = cbo_offtime.Text;

            int ontime_command = ontime * converion[timeunit_ontime];
            int offtime_command = offtime * converion[timeunit_offtime];

            int total_time = (ontime_command + offtime_command) * number;

            int total_time_h = total_time / 3600000;
            int total_time_h_remain = total_time % 3600000;

            int total_time_min = total_time_h_remain / 60000;
            int total_time_min_remain = total_time_h_remain % 60000;

            int total_time_sec = total_time_min_remain / 1000;

            string total_time_string;

            if (total_time_h < 1 && total_time_min < 1)
            {
                total_time_string = total_time_sec + " sec";
            }
            else if (total_time_h < 1)
            {
                total_time_string = total_time_min.ToString() + ":" + total_time_sec + " min";
            }
            else
            {
                total_time_string = total_time_h.ToString() + ":" + total_time_min.ToString() + ":" + total_time_sec + " hour";
            }

            string content = "On Time: " + txt_ontime.Text + timeunit_ontime;
            content += "\tOff Time: " + txt_offtime.Text + timeunit_offtime;
            content += "\tNumber: " + txt_number.Text;
            content += "\tTotal Time: " + total_time_string;

            list_box.Items.Add(content);

            ontime_list.Add(ontime_command);
            offtime_list.Add(offtime_command);
            number_list.Add(number);

            ontimeunit_list.Add(timeunit_ontime);
            offtimeunit_list.Add(timeunit_offtime);

        }

        public void list_box_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Speichern der daten die in der Listbox markiert wurde.
            listbox_item = list_box.SelectedItem;
            listbox_index = list_box.SelectedIndex;
        }

        private void btn_save_Click(object sender, EventArgs e)
        {

            for (int i = 0; i < offtime_list.Count; i++)
            {
                file_string += ontime_list[i].ToString() + delimiter;
                file_string += ontimeunit_list[i].ToString() + delimiter;
                file_string += offtime_list[i].ToString() + delimiter;
                file_string += offtimeunit_list[i].ToString() + delimiter;
                file_string += number_list[i].ToString() + delimiter;

            }

            save_file.Filter = "Text files (*.txt)|*.txt";

            if (save_file.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(save_file.FileName, file_string);
            }

            file_string = "";
        }

        // Wird von dem Button Stop sowie bei einem Fehler im Arduino aufgerufen.
        void stop_state()
        {

            // Command an Arduino, damit dieser stopt! Muss dementsprechend programmiert werden.
            try
            {
                SP.Write("S");
            }
            catch
            {
                // do nothing
            }
            

            started = false;

            progress_bar.Value = 0;

            btn_start_stop.Text = "Start";
            lbl_zeit.Text = "";
            btn_eingabe.Enabled = true;
            btn_load.Enabled = true;
            //btn_start_stop.BackColor = (255; 100; 255; 255) ;
            btn_start_stop.Image = USD.Properties.Resources.play;
            timer.Stop();

            btn_pause.Enabled = false;
            btn_pause.Text = "Pause";
            btn_pause.Image = USD.Properties.Resources.pause;

            paused = false;

            return;
        }

        private void btn_start_stop_Click(object sender, EventArgs e)
        {

            if (!started)
            {
                started = true;

                btn_eingabe.Enabled = false;
                btn_load.Enabled = false;
                btn_pause.Enabled = true;

                btn_start_stop.Text = "Stop";
                btn_start_stop.Image = USD.Properties.Resources.stop;

                all_time_sum = 0;

                for (int i = 0; i < ontime_list.Count; i++)
                {
                    int buffer_time = (ontime_list[i] + offtime_list[i]) * number_list[i];

                    all_time_sum += buffer_time;

                }

                Console.WriteLine(all_time_sum);

                all_time_h = all_time_sum / 3600000;
                int all_time_h_remain = all_time_sum % 3600000;

                all_time_min = all_time_h_remain / 60000;
                int all_time_min_remain = all_time_h_remain % 60000;

                all_time_sec = all_time_min_remain / 1000;

                // Timer start für den Rückwerts Zähler
                timer.Start();

                // Start Befehl für den Arduino.
                string arduino_command = "L";

                for(int i = 0; i < offtime_list.Count; i++)
                {
                    // Alle Sequenzen zusammen gefasst und in den String arduino_command geworfen.
                    arduino_command += ontime_list[i].ToString() + delimiter;
                    arduino_command += offtime_list[i].ToString() + delimiter;
                    arduino_command += number_list[i].ToString() + delimiter;

                    // Endungen für den Arduino um zu unterscheiden zwischen Sequenz-Ende und Test-Ende.
                    if (i == offtime_list.Count - 1)
                    {
                        arduino_command += "EOT;";
                    }
                    else
                    {
                        arduino_command += "EOL;";
                    }
                }

                // Befehl für das Starten + alle Elemente an den Arduino schicken.
                Console.WriteLine(arduino_command);
                SP.Write(arduino_command);
            }
            else
            {
                stop_state();

            }
        }

        private void btn_pause_Click(object sender, EventArgs e)
        {

            if (!paused)
            {
                // Arduino Code dementsprechend anpassen. (Pause stoppen des Tests)
                SP.Write("P");

                btn_pause.Text = "Weiter";
                btn_pause.Image = USD.Properties.Resources.play;

                timer.Stop();
                paused = true;
            }
            else
            {
                // Arduino Code dementsprechend anpassen. (Weiter nach Pause)
                SP.Write("W");
                
                btn_pause.Text = "Pause";
                btn_pause.Image = USD.Properties.Resources.pause;

                timer.Start();
                paused = false;
            }
        }

        private static T[,] Make2DArray<T>(T[] input, int height, int width)
        {
            T[,] output = new T[height, width];
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    output[i, j] = input[i * width + j];
                }
            }
            return output;
        }

        private void btn_load_Click(object sender, EventArgs e)
        {


            if (open_file.ShowDialog() == DialogResult.OK)
            {
                string filename = open_file.FileName;

                using (var reader = new StreamReader(filename))
                {
                    line = reader.ReadLine();
                }
                if (connected)
                {
                    btn_start_stop.Enabled = true;
                }
                

                // Listen Leeren damit nichts ...
                ontime_list.Clear();
                offtime_list.Clear();
                number_list.Clear();
                ontimeunit_list.Clear();
                offtimeunit_list.Clear();

                list_box.Items.Clear();

                string[] sep_lines = line.Split(';');

                int count_lines = sep_lines.Count() / 5;

                var array2d = Make2DArray(sep_lines, count_lines, 5);

                for (int i = 0; i <= count_lines - 1; i++)
                {

                    ontime_list.Add(Int32.Parse(array2d[i, 0]));
                    offtime_list.Add(Int32.Parse(array2d[i, 2]));
                    number_list.Add(Int32.Parse(array2d[i, 4]));
                    ontimeunit_list.Add(array2d[i, 1]);
                    offtimeunit_list.Add(array2d[i, 3]);


                    int conv_ontime = Int32.Parse(array2d[i, 0]) / converion[array2d[i, 1]];
                    int conv_offtime = Int32.Parse(array2d[i, 2]) / converion[array2d[i, 3]];

                    string content = "On Time: " + conv_ontime.ToString() + array2d[i, 1] + "\tOff Time: " + conv_offtime.ToString() + array2d[i, 3] + "\tNumber: " + array2d[i, 4];

                    list_box.Items.Add(content);
                }
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {

            if (!SP.IsOpen)
            {
                stop_state();
                
                MessageBox.Show("Verbindung zu dem Arduino verloren", "Verbindungsfehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (error)
            {
                stop_state();
                return;
            }

            lbl_zeit.Text = "Verbleibende Zeit: " + all_time_h.ToString() + ":" + all_time_min.ToString() + ":" + all_time_sec.ToString();

            all_time_sec -= 1;

            int current_sum = (all_time_h * 3600000 + all_time_min * 60000 + all_time_sec * 1000);

            int procent_bar = (all_time_sum - current_sum) * 100 / all_time_sum ;

            if (procent_bar <= 100)
            {
                progress_bar.Value = procent_bar;
            }
            
            if (all_time_sec < 0)
            {
                if(all_time_min == 0 && all_time_h == 0)
                {
                    timer.Stop();
                    
                    progress_bar.Value = 0;

                    btn_start_stop.Text = "Start";
                    btn_start_stop.Image = USD.Properties.Resources.play;
                    btn_eingabe.Enabled = true;
                    btn_load.Enabled = true;
                    started = false;

                    btn_pause.Enabled = false;
                    btn_pause.Text = "Pause";
                    btn_pause.Image = USD.Properties.Resources.pause;

                    MessageBox.Show("Test wurde beendet.", "Testende", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }

                all_time_min -= 1;
                all_time_sec = 59;
                
                if(all_time_min < 0)
                {
                    all_time_h -= 1;
                    all_time_min = 59;
                }
            }
        }

        private void list_box_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Delete)
            {
                // Notwending um ein Fehler zu vermeiden, wenn kein Item selectiert ist. (-1)
                if (listbox_index >= 0)
                {
                    

                    // Entfernen der daraus resultierenden Daten in den Listen.
                    ontime_list.RemoveAt(listbox_index);
                    offtime_list.RemoveAt(listbox_index);
                    number_list.RemoveAt(listbox_index);
                    ontimeunit_list.RemoveAt(listbox_index);
                    offtimeunit_list.RemoveAt(listbox_index);

                    // Entfernen des Items in der Listbox.
                    list_box.Items.Remove(listbox_item);

                    try
                    {
                        list_box.SetSelected(0, false);
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        Console.WriteLine("Catch");
                        btn_start_stop.Enabled = false;
                    }

                }
            }
        }

        private void connect_timer_Tick(object sender, EventArgs e)
        {
            findarduino();
        }
    }
}


    