using System.Numerics;

namespace _11_NumericTypesSuggester
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private BigInteger _minNumber;
        private BigInteger _maxNumber;

        private void minValueTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!IsValid(e.KeyChar, minValueTextBox.Text))
            {
                e.Handled = true;
            }
        }
        private void MinValueTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (BigInteger.TryParse(minValueTextBox.Text, out _minNumber))
            {
                SuggestType();
            }
        }
        private void maxValueTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!IsValid(e.KeyChar, maxValueTextBox.Text))
            {
                e.Handled = true;
            }
        }
        private void maxValueTextBox_KeyUp(object sender, KeyEventArgs e)
        {

            if (BigInteger.TryParse(maxValueTextBox.Text, out _maxNumber))
            {

                SuggestType();
            }


        }

        private void SuggestType()
        {
            if (_minNumber > _maxNumber)
            {
                typeData.Text = "not enough data";
                maxValueTextBox.BackColor = Color.Red;
            }
            else
            {
                maxValueTextBox.BackColor = Color.White;
                SelectMethodByConditions();
            }



        }

        private void SelectMethodByConditions()
        {
            if (integralCheckbox.Checked == true)
            {
                IntegralTypeSuggester();
            }
            else
            {
                if (precisionChecker.Checked == true)
                {
                    PrecisionSignedTypeSuggester();
                }
                else
                {
                    SignedTypeSuggester();
                }

            }
        }

        private void PrecisionSignedTypeSuggester()
        {
            if (decimal.TryParse(minValueTextBox.Text, out var _minDecimalValue) && _minDecimalValue >= decimal.MinValue && decimal.TryParse(maxValueTextBox.Text, out var _maxDecimalValue) && _maxDecimalValue <= decimal.MaxValue)
            {
                typeData.Text = "Decimal";
            }
            else
            {
                PrintImpossibleRepresentation();
            }
        }

        private void PrintImpossibleRepresentation()
        {
            typeData.Text = "Impossible representation";
        }

        private void SignedTypeSuggester()
        {

            if ((float)_minNumber >= float.MinValue && (float)_maxNumber <= float.MaxValue)
            {
                typeData.Text = "Float";
                return;
            }
            else if ((double)_minNumber >= double.MinValue && (double)_maxNumber <= double.MaxValue)
            {
                typeData.Text = "double";
                return;
            }
            else
            {
                PrintImpossibleRepresentation();
            }
        }

        private void IntegralTypeSuggester()
        {
            if (_minNumber >= uint.MinValue && _maxNumber <= uint.MaxValue)
            {
                typeData.Text = "uint";
                return;
            }
            else if (_minNumber >= sbyte.MinValue && _maxNumber <= sbyte.MaxValue)
            {
                typeData.Text = "sbyte";
            }
            else if (_minNumber >= short.MinValue && _maxNumber <= short.MaxValue)
            {
                typeData.Text = "short";
            }
            else if (_minNumber >= int.MinValue && _maxNumber <= int.MaxValue)
            {
                typeData.Text = "int";
                return;
            }
            else  
            {
                typeData.Text = "Big Integer";
                return;
            }
        }

        private void IntegralOnly_CheckStateChanged(object sender, EventArgs e)
        {
            EnableAndDisablePrecisionField();
            SuggestType();


        }

        private void EnableAndDisablePrecisionField()
        {
            precisionChecker.Visible = !precisionChecker.Visible;
            MustbePrecise.Visible = !MustbePrecise.Visible;
        }

        private void precisionChecker_CheckedChanged(object sender, EventArgs e)
        {
            SuggestType();
        }


        private bool IsValid(char keyChar, string currentText)
        {
            return char.IsNumber(keyChar) || char.IsControl(keyChar) || (keyChar == '-' && currentText == "");
        }




    }
}
