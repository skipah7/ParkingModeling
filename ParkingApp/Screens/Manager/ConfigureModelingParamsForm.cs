using ParkingApp.Classes.BaseParkingClasses;
using ParkingApp.Classes.ModelingClasses;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ParkingApp.Screens.Manager
{
    public partial class ConfigureModelingParamsForm : Form
    {
        public ConfigureModelingParamsForm()
        {
            InitializeComponent();
            setUpGUI();
        }

        private void setUpGUI()
        {
            uniformPanel.Visible = false;
            normalPanel.Visible = false;

            exponTextBox.Visible = false;
            label15.Visible = false;

            //стоянка
            aOnParkingIntervalTB.Visible = false;
            bOnParkingIntervalTB.Visible = false;
            label24.Visible = false;
            label23.Visible = false;

            lambdaOnParkingIntervalTB.Visible = false;
            label22.Visible = false;

            MXonParkingIntervalTB.Visible = false;
            DXonParkingIntervalTB.Visible = false;
            label20.Visible = false;
            label21.Visible = false;

            trackBar1.Value = 2;
        }

        private void probabilityTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar) || e.KeyChar.Equals(',')))
            {
                e.Handled = true;
            }
        }

        private bool isInputsCorrect()
        {
            bool result = true;
            if (onParkingIntervalTextBox.Text.Length == 0)
            {
                MessageBox.Show("Необходимо заполинть все доступные поля", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
                result = false;
            }
            if (result)
            {
                if (!((int.Parse(onParkingIntervalTextBox.Text) <= 10000) && (int.Parse(onParkingIntervalTextBox.Text) > 4)))
                {
                    MessageBox.Show("Минимальное интервала стоянки 5, максимальное 10 000", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    result = false;
                }
            }
            return result;
        }

        private void appearanceIntervalTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        List<double> onParkingIntervals;
        List<double> appearanceIntervals;
        private void button1_Click(object sender, EventArgs e)
        {
            if (determinisicFlowButton.Checked)
            {
                if (isInputsCorrect())
                {
                    Globals.modelingParams = new ModelingParams(
                        true, 
                        lightCarProbability.Value / 100d,
                        deterministicAppearanceInterval.Value, 
                        int.Parse(onParkingIntervalTextBox.Text)
                    );
                    setPlaySpeed();
                    Globals.calculateDelta();
                    ManagerMainScreen managerMainScreen = new ManagerMainScreen();
                    managerMainScreen.Show();
                    this.Hide();
                }
            }
            else
            {
                if (isTypeOfDistributionChoosed() && onParkingDistributionChoosed())
                {
                    DistributionsClass distributions = new DistributionsClass();
                    onParkingIntervals = new List<double>();
                    appearanceIntervals = new List<double>();
                    if (typeOfDistributionLowComboBox.SelectedIndex == 0 && checkUniformValues())
                    {
                        appearanceIntervals = distributions.generateUniformValues(aValue.Value, bValue.Value);
                    }
                    else if (typeOfDistributionLowComboBox.SelectedIndex == 1 && checkExponentialInputs())
                    {
                        double lambda = double.Parse(exponTextBox.Text);
                        appearanceIntervals = distributions.generateExponentialValues(lambda);
                    }
                    else if (typeOfDistributionLowComboBox.SelectedIndex == 2)
                    {
                        appearanceIntervals = distributions.generateNormalValues(MXValue.Value, DXValue.Value / 100d);
                    }

                    if(comboBox1.SelectedIndex == 0 && checkUniformValuesOnParking())
                    {
                        double a = double.Parse(aOnParkingIntervalTB.Text);
                        double b = double.Parse(bOnParkingIntervalTB.Text);
                        onParkingIntervals = distributions.generateUniformValues(a, b);
                    } else if(comboBox1.SelectedIndex == 1 && checkExponentialInputsOnParking())
                    {
                        double lambda = double.Parse(lambdaOnParkingIntervalTB.Text);
                        onParkingIntervals = distributions.generateExponentialValues(lambda);
                    } else if(comboBox1.SelectedIndex == 2 && checkNormalInputsOnParking())
                    {
                        double MX = double.Parse(MXonParkingIntervalTB.Text);
                        double DX = double.Parse(DXonParkingIntervalTB.Text);
                        onParkingIntervals = distributions.generateNormalValues(MX, DX);
                    }

                    if(appearanceIntervals.Count!=0 && onParkingIntervals.Count != 0)
                    {
                        Globals.modelingParams = new ModelingParams(
                            true,
                            lightCarProbability.Value / 100d,
                            appearanceIntervals,
                            onParkingIntervals
                        );
                        setPlaySpeed();
                        Globals.calculateDelta();
                        ManagerMainScreen managerMainScreen = new ManagerMainScreen();
                        managerMainScreen.Show();
                        this.Hide();
                    }
                }
                else
                {
                    MessageBox.Show("Пожалуйста, заполните все доступные поля", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        //экспоненциальный от 0.001 - 1
        //нормальный МХ от 0 до 5000 DX от 0.1 до 3
        //равномерный a от 1 до 9999 b от 2 до 10000
        
        private bool checkNormalInputsOnParking()
        {
            if (MXonParkingIntervalTB.Text.Length == 0 || DXonParkingIntervalTB.Text.Length == 0)
            {
                MessageBox.Show("Пожалуйста, заполните все доступные поля", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (double.TryParse(MXonParkingIntervalTB.Text, out double MX))
            {
                if (double.TryParse(DXonParkingIntervalTB.Text, out double DX))
                {
                    if (MX >= 0 && MX <= 5000)
                    {
                        if (DX >= 0.1 && DX <= 3)
                        {
                            return true;
                        }
                        else
                        {
                            MessageBox.Show("DX минимальное = 0.1, MX максимальное = 3", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("MX минимальное = 0, MX максимальное = 5000", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("DX должно быть вещественным", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("MX должно быть вещественным", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }

        private bool checkExponentialInputsOnParking()
        {
            if (lambdaOnParkingIntervalTB.Text.Length == 0)
            {
                MessageBox.Show("Пожалуйста, заполните все доступные поля", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (double.TryParse(lambdaOnParkingIntervalTB.Text, out double a))
            {
                if (a >= 0.001 && a <= 1)
                {
                    return true;
                }
                else
                {
                    MessageBox.Show("λ минимальное = 0.001,  λ максимальное = 1", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("λ должно быть вещественным", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }

        private bool checkUniformValuesOnParking()
        {
            if (aOnParkingIntervalTB.Text.Length == 0 || bOnParkingIntervalTB.Text.Length == 0)
            {
                MessageBox.Show("Пожалуйста, заполните все доступные поля", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (double.TryParse(aOnParkingIntervalTB.Text, out double a))
            {
                if (double.TryParse(bOnParkingIntervalTB.Text, out double b))
                {
                    if (a < b)
                    {
                        if (a >= 1 && b <= 10000)
                        {
                            return true;
                        }
                        else
                        {
                            MessageBox.Show("a минимальное = 1, b максимальное = 10 000", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("a должно быть меньше чем b", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("b должно быть вещественным", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("a должно быть вещественным", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }

        private bool isTypeOfDistributionChoosed()
        {
            if (typeOfDistributionLowComboBox.SelectedIndex == 0 ||
                typeOfDistributionLowComboBox.SelectedIndex == 1 ||
                typeOfDistributionLowComboBox.SelectedIndex == 2)
            {
                return true;
            }
            return false;
        }

        private bool onParkingDistributionChoosed()
        {
            bool result = false;
            if (comboBox1.SelectedIndex == 0)
            {
                result = true;
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                result = true;
            }
            else if (comboBox1.SelectedIndex == 2)
            {
                result = true;
            }
            else
            {
                result = false;
            }
            return result;
        }

        private void setPlaySpeed()
        {
            if (trackBar1.Value == 1)
            {
                Globals.INTERVAL = 40;
            }
            else if (trackBar1.Value == 2)
            {
                Globals.INTERVAL = 20;
            }
            else if (trackBar1.Value == 3)
            {
                Globals.INTERVAL = 10;
            }
            else
            {
                Globals.INTERVAL = 5;
            }
        }

        private bool checkUniformValues()
        {
            if (aValue.Value > bValue.Value)
            {
                MessageBox.Show("a должно быть меньше чем b", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private bool checkExponentialInputs()
        {
            if (exponTextBox.Text.Length == 0)
            {
                MessageBox.Show("Пожалуйста, заполните все доступные поля", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (double.TryParse(exponTextBox.Text, out double a))
            {
                if (a >= 0.008 && a <= 2)
                {
                    return true;
                }
                else
                {
                    MessageBox.Show("λ минимальное = 0.008,  λ максимальное = 2", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("λ должно быть вещественным", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }  

        private void typeOfDistributionLowComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            adjustSelectBox();
        }

        private void adjustSelectBox()
        {
            if (typeOfDistributionLowComboBox.SelectedIndex == 0)
            {
                normalPanel.Visible = false;

                exponTextBox.Visible = false;
                label15.Visible = false;

                uniformPanel.Visible = true;
                uniformPanel.BringToFront();
            }
            if (typeOfDistributionLowComboBox.SelectedIndex == 1)
            {
                uniformPanel.Visible = false;
                normalPanel.Visible = false;

                exponTextBox.Visible = true;
                label15.Visible = true;
            }
            if (typeOfDistributionLowComboBox.SelectedIndex == 2)
            {
                uniformPanel.Visible = false;

                exponTextBox.Visible = false;
                label15.Visible = false;

                normalPanel.Visible = true;
                normalPanel.BringToFront();
            }
        }

        private void randomFlowSelected(object sender, EventArgs e)
        {
            if (HazardFlowRadioBtn.Checked)
            {
                adjustSelectBox();

                label7.Enabled = false;
                deterministicAppearanceInterval.Visible = false;
                deterministicLabel.Visible = false;
                onParkingIntervalTextBox.Enabled = false;

                typeOfDistributionLowComboBox.Visible = true;

                exponTextBox.Enabled = true;
                label15.Enabled = true;

                //Стоянка на паркинге
                comboBox1.Enabled = true;

                MXonParkingIntervalTB.Enabled = true;
                DXonParkingIntervalTB.Enabled = true;
                label20.Enabled = true;
                label21.Enabled = true;

                lambdaOnParkingIntervalTB.Enabled = true;
                label22.Enabled = true;

                aOnParkingIntervalTB.Enabled = true;
                bOnParkingIntervalTB.Enabled = true;
                label24.Enabled = true;
                label23.Enabled = true;
            }
            else
            {
   
                label7.Enabled = true;
                deterministicAppearanceInterval.Visible = true;
                deterministicLabel.Visible = true;
                onParkingIntervalTextBox.Enabled = true;

                typeOfDistributionLowComboBox.Visible = false;

                uniformPanel.Visible = false;
                normalPanel.Visible = false;

                exponTextBox.Enabled = false;
                label15.Enabled = false;

                //стоянка на паркинге
                comboBox1.Enabled = false;

                MXonParkingIntervalTB.Enabled = false;
                DXonParkingIntervalTB.Enabled = false;
                label20.Enabled = false;
                label21.Enabled = false;

                lambdaOnParkingIntervalTB.Enabled = false;
                label22.Enabled = false;

                aOnParkingIntervalTB.Enabled = false;
                bOnParkingIntervalTB.Enabled = false;
                label24.Enabled = false;
                label23.Enabled = false;
            }
        }

        private void onParkingIntervalCB(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                aOnParkingIntervalTB.Visible = true;
                bOnParkingIntervalTB.Visible = true;
                label24.Visible = true;
                label23.Visible = true;

                lambdaOnParkingIntervalTB.Visible = false;
                label22.Visible = false;

                MXonParkingIntervalTB.Visible = false;
                DXonParkingIntervalTB.Visible = false;
                label20.Visible = false;
                label21.Visible = false;
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                aOnParkingIntervalTB.Visible = false;
                bOnParkingIntervalTB.Visible = false;
                label24.Visible = false;
                label23.Visible = false;

                lambdaOnParkingIntervalTB.Visible = true;
                label22.Visible = true;

                MXonParkingIntervalTB.Visible = false;
                DXonParkingIntervalTB.Visible = false;
                label20.Visible = false;
                label21.Visible = false;
            }
            else
            {
                aOnParkingIntervalTB.Visible = false;
                bOnParkingIntervalTB.Visible = false;
                label24.Visible = false;
                label23.Visible = false;

                lambdaOnParkingIntervalTB.Visible = false;
                label22.Visible = false;

                MXonParkingIntervalTB.Visible = true;
                DXonParkingIntervalTB.Visible = true;
                label20.Visible = true;
                label21.Visible = true;
            }
        }

        #region helpers
        private void preventResize(object sender, EventArgs e)
        {
             WindowState = FormWindowState.Normal;
        }

        private void shutDownApplication(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void backToAdminMainScreen_Click(object sender, EventArgs e)
        {
            this.Hide();
            ManagerMainScreen managerMainScreen = new ManagerMainScreen();
            managerMainScreen.Show();
        }

        #endregion
    }
}
