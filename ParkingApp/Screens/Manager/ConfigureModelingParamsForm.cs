using ParkingApp.Classes.BaseParkingClasses;
using ParkingApp.Classes.ModelingClasses;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ParkingApp.Screens.Manager
{
    public partial class ConfigureModelingParamsForm : Form
    {
        Panel[] flowPanels;
        Panel[] parkPanels;

        public ConfigureModelingParamsForm()
        {
            InitializeComponent();
            flowPanels = new[] { uniformFlowPanel, exponentialFlowPanel, normalFlowPanel };
            parkPanels = new[] { uniformParkPanel, exponentialParkPanel, normalParkPanel };

            flowLawType.SelectedIndex = 0;
            parkLawType.SelectedIndex = 0;
        }

        private void saveModellingParams(object sender, EventArgs e)
        {
            var flowLawType = determinisicFlowButton.Checked ? LawTypes.Deterministic : (LawTypes)this.flowLawType.SelectedIndex;
            var parkLawType = deterministicParkButton.Checked ? LawTypes.Deterministic : (LawTypes)this.parkLawType.SelectedIndex;

            var flowValues = new Dictionary<string, double>();
            if (flowLawType == LawTypes.Deterministic) {
                flowValues.Add("interval", deterministicFlowInterval.Value); 
            }
            if (flowLawType == LawTypes.Uniform && checkABValues(flowAValue.Value, flowBValue.Value)) {
                flowValues.Add("a", flowAValue.Value);
                flowValues.Add("b", flowBValue.Value);
            }
            if (flowLawType == LawTypes.Exponential)
            {
                flowValues.Add("lambda", exponentialFlowValue.Value / 100d);
            }
            if (flowLawType == LawTypes.Normal)
            {
                flowValues.Add("MX", flowMXValue.Value);
                flowValues.Add("DX", flowDXValue.Value / 100d);
            }

            var parkValues = new Dictionary<string, double>();
            if (parkLawType == LawTypes.Deterministic)
            {
                parkValues.Add("interval", deterministicParkInterval.Value);
            }
            if (parkLawType == LawTypes.Uniform && checkABValues(parkAValue.Value, parkBValue.Value))
            {
                parkValues.Add("a", parkAValue.Value);
                parkValues.Add("b", parkBValue.Value);
            }
            if (parkLawType == LawTypes.Exponential)
            {
                parkValues.Add("lambda", exponentialParkValue.Value / 1000d);
            }
            if (parkLawType == LawTypes.Normal)
            {
                parkValues.Add("MX", parkMXValue.Value);
                parkValues.Add("DX", parkDXValue.Value / 100d);
            }

            if ((flowValues.Count == 0) || (parkValues.Count == 0)) return;

            var lightToHeavyRatio = this.lightToHeavyRatio.Value / 100d;
            var lightCarProbability = this.lightCarProbability.Value / 100d;
            var heavyCarProbability = this.heavyCarProbability.Value / 100d;

            Globals.modelingParams = new ModelingParams(flowLawType, parkLawType, flowValues, parkValues, lightToHeavyRatio, lightCarProbability, heavyCarProbability);
            Globals.tariff = createTariff();

            ManagerMainScreen managerMainScreen = new ManagerMainScreen();
            managerMainScreen.Show();
            this.Hide();
            //Globals.calculateDelta();
        }

        private Tariff createTariff()
        {
            int carPrice = 100;
            Tariff tariff;
            tariff = new Tariff(Globals.HOURLY_RATE, carPrice);
            tariff = new Tariff(Globals.DAILY_RATE, carPrice);
            return tariff;
        }

        #region UIHelpers
        private void showTooltip(object sender, EventArgs e)
        {
            trackBarTooltip.SetToolTip(sender as TrackBar, (sender as TrackBar).Value.ToString());
        }

        private void showTooltipDividedBy10(object sender, EventArgs e)
        {
            trackBarTooltip.SetToolTip(sender as TrackBar, ((sender as TrackBar).Value / 10d).ToString());
        }

        private void showTooltipDividedBy100(object sender, EventArgs e)
        {
            trackBarTooltip.SetToolTip(sender as TrackBar, ((sender as TrackBar).Value / 100d).ToString());
        }

        private void showTooltipDividedBy1000(object sender, EventArgs e)
        {
            trackBarTooltip.SetToolTip(sender as TrackBar, ((sender as TrackBar).Value / 1000d).ToString());
        }

        private bool checkABValues(int a, int b)
        {
            if (a > b)
            {
                MessageBox.Show("a должно быть меньше чем b", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void validation(object sender, EventArgs e)
        {
            (sender as NumericUpDown).Value = (sender as NumericUpDown).Value;
        }

        private void flawLawTypeSelection(object sender, EventArgs e)
        {
            adjustSelectBox(flowPanels, flowLawType);
        }

        private void parkLawTypeSelection(object sender, EventArgs e)
        {
            adjustSelectBox(parkPanels, parkLawType);
        }

        private void adjustSelectBox(Panel[] panels, ComboBox comboBox)
        {
            for (int i = 0; i < panels.Length; i++)
            {
                panels[i].Visible = comboBox.SelectedIndex == i;
            }
        }

        private void randomParkSelected(object sender, EventArgs e)
        {
            if (randomParkButton.Checked)
            {
                deterministicParkPanel.Visible = false;
                randomParkPanel.Visible = true;

                adjustSelectBox(parkPanels, parkLawType);
            }
            if (deterministicParkButton.Checked)
            {
                randomParkPanel.Visible = false;
                deterministicParkPanel.Visible = true;
            }
        }

        private void randomFlowSelected(object sender, EventArgs e)
        {
            if (randomFlowButton.Checked)
            {
                deterministicFlowPanel.Visible = false;
                randomFlowPanel.Visible = true;

                adjustSelectBox(flowPanels, flowLawType);
            }
            if (determinisicFlowButton.Checked)
            {
                randomFlowPanel.Visible = false;
                deterministicFlowPanel.Visible = true;
            }
        }
        #endregion

        #region helpers
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
