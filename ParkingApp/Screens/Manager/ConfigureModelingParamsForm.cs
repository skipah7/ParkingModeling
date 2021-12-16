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

        List<double> onParkingIntervals;
        List<double> appearanceIntervals;
        private void button1_Click(object sender, EventArgs e)
        {
            if (determinisicFlowButton.Checked)
            {
                Globals.modelingParams = new ModelingParams(
                    true,
                    lightCarProbability.Value / 100d,
                    deterministicAppearanceFlow.Value,
                    deterministicParkInterval.Value
                );
                Globals.calculateDelta();
                ManagerMainScreen managerMainScreen = new ManagerMainScreen();
                managerMainScreen.Show();
                this.Hide();
            }
            else
            {
                DistributionsClass distributions = new DistributionsClass();
                onParkingIntervals = new List<double>();
                appearanceIntervals = new List<double>();
                if (flowLawType.SelectedIndex == 0 && checkABValues(flowAValue.Value, flowBValue.Value))
                {
                    appearanceIntervals = distributions.generateUniformValues(flowAValue.Value, flowBValue.Value);
                }
                else if (flowLawType.SelectedIndex == 1)
                {
                    appearanceIntervals = distributions.generateExponentialValues(exponentialFlowValue.Value / 100d);
                }
                else if (flowLawType.SelectedIndex == 2)
                {
                    appearanceIntervals = distributions.generateNormalValues(flowMXValue.Value, flowDXValue.Value / 100d);
                }

                if (parkLawType.SelectedIndex == 0 && checkABValues(parkAValue.Value, parkBValue.Value))
                {
                    onParkingIntervals = distributions.generateUniformValues(parkAValue.Value, parkBValue.Value);
                }
                else if (parkLawType.SelectedIndex == 1)
                {
                    onParkingIntervals = distributions.generateExponentialValues(exponentialParkValue.Value / 1000d);
                }
                else if (parkLawType.SelectedIndex == 2)
                {
                    onParkingIntervals = distributions.generateNormalValues(parkMXValue.Value, parkDXValue.Value / 100d);
                }

                if (appearanceIntervals.Count != 0 && onParkingIntervals.Count != 0)
                {
                    Globals.modelingParams = new ModelingParams(
                        true,
                        lightCarProbability.Value / 100d,
                        appearanceIntervals,
                        onParkingIntervals
                    );
                    Globals.calculateDelta();
                    Globals.tariff = createTariff();
                    ManagerMainScreen managerMainScreen = new ManagerMainScreen();
                    managerMainScreen.Show();
                    this.Hide();
                }
            }
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
            startTimeHours.Value = startTimeHours.Value;
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
