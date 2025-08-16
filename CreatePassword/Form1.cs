namespace CreatePassword
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int length_pass = (int)numericUpDown1.Value;
            if (length_pass == 0)
            {
                MessageBox.Show("Password length can't be 0!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var rnd = new Random();
            string[] characters = {
        "a","b","c","d","e","f","g","h","i","j","k","l","m","n","o","p","r","s","t","u","v","y","z","w","q","x",
        "A","B","C","D","E","F","G","H","I","J","K","L","M","N","O","P","R","S","T","U","V","Y","Z","W","Q","X",
        "1","2","3","4","5","6","7","8","9","0",
        "*","-","?","=","_",")","(","/","&","%","+","^","'","!","<",">",".",":",",",";","|","}","]","[","{","$","#","£","~","€","@"
    };

            string[] digits = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
            string[] upperchars = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "R", "S", "T", "U", "V", "Y", "Z", "W", "Q", "X" };
            string[] lowerchars = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "r", "s", "t", "u", "v", "y", "z", "w", "q", "x" };
            string[] specialchars = { "*", "-", "?", "=", "_", ")", "(", "/", "&", "%", "+", "^", "'", "!", "<", ">", ".", ":", ",", ";", "|", "}", "]", "[", "{", "$", "#", "£", "~", "€", "@" };


            string password = "";
            for (int i = 0; i < length_pass; i++)
            {
                password += characters[rnd.Next(characters.Length)];
            }


            char[] passwordChars = password.ToCharArray();


            bool hasUpper = false, hasLower = false, hasDigit = false, hasSpecial = false;

            foreach (char ch in passwordChars)
            {
                if (char.IsUpper(ch)) hasUpper = true;
                else if (char.IsLower(ch)) hasLower = true;
                else if (char.IsDigit(ch)) hasDigit = true;
                else if (specialchars.Contains(ch.ToString())) hasSpecial = true;
            }

            void ReplaceRandomChar(Func<char> getChar)
            {
                int pos = rnd.Next(passwordChars.Length);
                passwordChars[pos] = getChar();
            }

            if (!hasUpper)
            {
                ReplaceRandomChar(() => upperchars[rnd.Next(upperchars.Length)][0]);
            }
            if (!hasLower)
            {
                ReplaceRandomChar(() => lowerchars[rnd.Next(lowerchars.Length)][0]);
            }
            if (!hasDigit)
            {
                ReplaceRandomChar(() => digits[rnd.Next(digits.Length)][0]);
            }
            if (!hasSpecial)
            {
                ReplaceRandomChar(() => specialchars[rnd.Next(specialchars.Length)][0]);
            }


            for (int i = passwordChars.Length - 1; i > 0; i--)
            {
                int j = rnd.Next(i + 1);
                char temp = passwordChars[i];
                passwordChars[i] = passwordChars[j];
                passwordChars[j] = temp;
            }

            password = new string(passwordChars);


            textBox1.Text = password;
        }

        private void buttonCopy_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text))
            {
                Clipboard.SetText(textBox1.Text);
                MessageBox.Show("Password copied to clipboard!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("No password found to copy.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}







