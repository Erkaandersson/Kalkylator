using Microsoft.VisualBasic.Devices;
using System.Data;

namespace Kalkylator
{

    public partial class Form1 : Form
    {
        //Skapar variabler float för numbers och answers som kan ta flyttal och göra uträkningar med.
        //Skapar en char variabel för att kunna ta signs, som ska användas till operatorer i switch-sats till uträkningar.
        float number1, number2, answer;
        char sign = ' ';
        // En lista för att spara historik för räkningar
        //Använder lista för den är dynamisk, där storleken kan ändras efter önskad input. Arrayer kräver en "storlek" 
        //när man deklarerar den, vilket inte skulle funka i detta fallet.
        List<string> calculations = new List<string>();

        public Form1()
        {
            InitializeComponent();
            // Välkomnande meddelande
            textBox3.Text = "Välkommen till kalkylatorn!" + Environment.NewLine + "Använd clear efter varje uträkning.";
        }
        //Användaren matar in matematiska operationer.
        //Deklarerar operatorer till variabel sign för att använda i switch-sats. Sätter värde på number1 
        //beroende på vilken siffra som är tryckt och parsar till en float.
        private void subtractBtn_Click(object sender, EventArgs e)
        {
            sign = '-';
            number1 = float.Parse(textBox1.Text);
            textBox1.Clear();
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            sign = '+';
            number1 = float.Parse(textBox1.Text);
            textBox1.Clear();
        }

        private void multiBtn_Click(object sender, EventArgs e)
        {
            sign = '*';
            number1 = float.Parse(textBox1.Text);
            textBox1.Clear();
        }

        private void slashBtn_Click(object sender, EventArgs e)
        {
            sign = '/';
            number1 = float.Parse(textBox1.Text);
            textBox1.Clear();
        }
        private void equalsBtn_Click(object sender, EventArgs e)
        {
            compute(sign);
        }
        // Lägga resultat till listan
        //funktion med switch-sats för att göra uträkningar beroende på vilken operator som är tryckt.
        //Och addera uträkningar till listan så som den ska skrivas ut till textbox3 i senare skede.
        public void compute(char sign)
        {
            number2 = float.Parse(textBox1.Text);
            switch (sign)
            {
                case '-':
                    answer = number1 - number2;
                    textBox1.Text = answer.ToString();
                    calculations.Add($"{number1} {sign} {number2} = {answer}");
                    break;

                case '+':
                    answer = number1 + number2;
                    textBox1.Text = answer.ToString();
                    calculations.Add($"{number1} {sign} {number2} = {answer}");
                    break;

                case '*':
                    answer = number1 * number2;
                    textBox1.Text = answer.ToString();
                    calculations.Add($"{number1} {sign} {number2} = {answer}");
                    break;

                case '/':
                    // Ifall användaren skulle dela med 0 visa Ogiltig inmatning!
                    if (number2 == 0)
                    {
                        textBox1.Text = "Cannot divide by zero" + Environment.NewLine;
                        break;
                    }
                    else
                    {
                        answer = number1 / number2;
                        textBox1.Text = answer.ToString();
                        calculations.Add($"{number1} {sign} {number2} = {answer}");
                        break;
                    }
                default:
                    break;
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //En kontrollstruktur för att inte kunna skriva bokstäver i textboxen för uträknmingar.
            string text = textBox1.Text;    
            foreach (char c in text)
            {
                if (!Char.IsDigit(c))
                {
                    textBox3.Text = "Endast siffror är tillåtna!";
      
                    textBox1.Clear();
                }
            }
        }
        // Användaren matar in tal
        //Knappar för att skriva ut siffran som är tryckt i textbox1.

        private void btn0_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + 0;
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + 1;
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + 2;
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + 3;
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + 4;
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + 5;
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + 6;
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + 7;
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + 8;
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + 9;
        }

        private void commaBtn_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + ",";
        }
        //För att rensa textbox 1, och göra en ny uträkning.
        private void cBtn_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "C";
            textBox1.Clear();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
        // Fråga användaren om den vill visa tidigare resultat.
        // Visa tidigare resultat, När man klickar på knappen uträkningar så används en foreach-loop för att skriva ut
        //listan och skriva ut varje på en ny rad.
        private void button2_Click(object sender, EventArgs e)
        {
            textBox3.Clear();

            foreach (string s in calculations)
            {
                textBox3.Text += s + Environment.NewLine;
            }
        }
        //En funktion för att rensa textbox3 rutan med uträkningar.
        private void button1_Click(object sender, EventArgs e)
        {
            textBox3.Clear();
        }
    }
}
