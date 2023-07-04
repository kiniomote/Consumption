using ConsumptionFuzzyLogic.FuzzyLogic.Accumulation;
using ConsumptionFuzzyLogic.FuzzyLogic.Activation;
using ConsumptionFuzzyLogic.FuzzyLogic.Defuzzification;
using ConsumptionFuzzyLogic.FuzzyLogic.Fuzzification;
using ConsumptionFuzzyLogic.FuzzyLogic.Rule;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsumptionFuzzyLogic
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            FuzzyLogicAlgorithm fuzzyLogicAlgorithm = new FuzzyLogicAlgorithm();
            
            ReadData(fuzzyLogicAlgorithm);

            double result = fuzzyLogicAlgorithm.Calculate(Convert.ToDouble(currentLevelUpDown.Value),
                                          Convert.ToDouble(consumptionUpDown.Value));
            answerLabel.Text = result.ToString();

            SetGraphics(result, fuzzyLogicAlgorithm);
        }

        private void ReadData(FuzzyLogicAlgorithm fuzzyLogicAlgorithm)
        {
            RulesBase rulesBase = new RulesBase();
            rulesBase.Rules.Add(new FuzzyLogic.Rule.Rule(Grade.Small, Grade.Big, ConvertTextToGrade(z1ComboBox.Text), Convert.ToDouble(f1UpDown.Value)));
            rulesBase.Rules.Add(new FuzzyLogic.Rule.Rule(Grade.Small, Grade.Medium, ConvertTextToGrade(z2ComboBox.Text), Convert.ToDouble(f2UpDown.Value)));
            rulesBase.Rules.Add(new FuzzyLogic.Rule.Rule(Grade.Small, Grade.Small, ConvertTextToGrade(z3ComboBox.Text), Convert.ToDouble(f3UpDown.Value)));
            rulesBase.Rules.Add(new FuzzyLogic.Rule.Rule(Grade.Medium, Grade.Big, ConvertTextToGrade(z4ComboBox.Text), Convert.ToDouble(f4UpDown.Value)));
            rulesBase.Rules.Add(new FuzzyLogic.Rule.Rule(Grade.Medium, Grade.Medium, ConvertTextToGrade(z5ComboBox.Text), Convert.ToDouble(f5UpDown.Value)));
            rulesBase.Rules.Add(new FuzzyLogic.Rule.Rule(Grade.Medium, Grade.Small, ConvertTextToGrade(z6ComboBox.Text), Convert.ToDouble(f6UpDown.Value)));
            rulesBase.Rules.Add(new FuzzyLogic.Rule.Rule(Grade.Big, Grade.Big, ConvertTextToGrade(z7ComboBox.Text), Convert.ToDouble(f7UpDown.Value)));
            rulesBase.Rules.Add(new FuzzyLogic.Rule.Rule(Grade.Big, Grade.Medium, ConvertTextToGrade(z8ComboBox.Text), Convert.ToDouble(f8UpDown.Value)));
            rulesBase.Rules.Add(new FuzzyLogic.Rule.Rule(Grade.Big, Grade.Small, ConvertTextToGrade(z9ComboBox.Text), Convert.ToDouble(f9UpDown.Value)));

            fuzzyLogicAlgorithm.RulesBase = rulesBase;

            fuzzyLogicAlgorithm.LevelFuzzificationData.Small.Top = Convert.ToDouble(z1LevelLineUpDown.Value);
            fuzzyLogicAlgorithm.LevelFuzzificationData.Small.Down = Convert.ToDouble(z2LevelLineUpDown.Value);

            fuzzyLogicAlgorithm.LevelFuzzificationData.Medium.LeftDown = Convert.ToDouble(t1LevelLineUpDown.Value);
            fuzzyLogicAlgorithm.LevelFuzzificationData.Medium.LeftTop = Convert.ToDouble(t2LevelLineUpDown.Value);
            fuzzyLogicAlgorithm.LevelFuzzificationData.Medium.RightTop = Convert.ToDouble(t3LevelLineUpDown.Value);
            fuzzyLogicAlgorithm.LevelFuzzificationData.Medium.RightDown = Convert.ToDouble(t4LevelLineUpDown.Value);

            fuzzyLogicAlgorithm.LevelFuzzificationData.Big.Down = Convert.ToDouble(s1LevelLineUpDown.Value);
            fuzzyLogicAlgorithm.LevelFuzzificationData.Big.Top = Convert.ToDouble(s2LevelLineUpDown.Value);

            fuzzyLogicAlgorithm.ConsumptionFuzzificationData.Small.Top = Convert.ToDouble(z1ConsLineUpDown.Value);
            fuzzyLogicAlgorithm.ConsumptionFuzzificationData.Small.Down = Convert.ToDouble(z2ConsLineUpDown.Value);

            fuzzyLogicAlgorithm.ConsumptionFuzzificationData.Medium.LeftDown = Convert.ToDouble(t1ConsLineUpDown.Value);
            fuzzyLogicAlgorithm.ConsumptionFuzzificationData.Medium.LeftTop = Convert.ToDouble(t2ConsLineUpDown.Value);
            fuzzyLogicAlgorithm.ConsumptionFuzzificationData.Medium.RightTop = Convert.ToDouble(t3ConsLineUpDown.Value);
            fuzzyLogicAlgorithm.ConsumptionFuzzificationData.Medium.RightDown = Convert.ToDouble(t4ConsLineUpDown.Value);

            fuzzyLogicAlgorithm.ConsumptionFuzzificationData.Big.Down = Convert.ToDouble(s1ConsLineUpDown.Value);
            fuzzyLogicAlgorithm.ConsumptionFuzzificationData.Big.Top = Convert.ToDouble(s2ConsLineUpDown.Value);

            fuzzyLogicAlgorithm.InflowFuzzificationData.Small.Top = Convert.ToDouble(z1InflowLineUpDown.Value);
            fuzzyLogicAlgorithm.InflowFuzzificationData.Small.Down = Convert.ToDouble(z2InflowLineUpDown.Value);

            fuzzyLogicAlgorithm.InflowFuzzificationData.Medium.LeftDown = Convert.ToDouble(t1InflowLineUpDown.Value);
            fuzzyLogicAlgorithm.InflowFuzzificationData.Medium.LeftTop = Convert.ToDouble(t2InflowLineUpDown.Value);
            fuzzyLogicAlgorithm.InflowFuzzificationData.Medium.RightTop = Convert.ToDouble(t3InflowLineUpDown.Value);
            fuzzyLogicAlgorithm.InflowFuzzificationData.Medium.RightDown = Convert.ToDouble(t4InflowLineUpDown.Value);

            fuzzyLogicAlgorithm.InflowFuzzificationData.Big.Down = Convert.ToDouble(s1InflowLineUpDown.Value);
            fuzzyLogicAlgorithm.InflowFuzzificationData.Big.Top = Convert.ToDouble(s2InflowLineUpDown.Value);

            fuzzyLogicAlgorithm.ActivationFunction = ConvertTextToActivation(activationComboBox.Text);
            fuzzyLogicAlgorithm.AccumulationFunction = ConvertTextToAccumulation(accumulationComboBox.Text);
            fuzzyLogicAlgorithm.DefuzzificationFunction = ConvertTextToDefuzzification(defuzzyficationComboBox.Text);
        }

        private void SetGraphics(double result, FuzzyLogicAlgorithm fuzzyLogicAlgorithm)
        {
            levelChart.Series[0].Points.Clear();
            levelChart.Series[0].Points.AddXY(1.5, 1);
            levelChart.Series[0].Points.AddXY(z1LevelLineUpDown.Value, 1);
            levelChart.Series[0].Points.AddXY(z2LevelLineUpDown.Value, 0);

            levelChart.Series[1].Points.Clear();
            levelChart.Series[1].Points.AddXY(t1LevelLineUpDown.Value, 0);
            levelChart.Series[1].Points.AddXY(t2LevelLineUpDown.Value, 1);
            levelChart.Series[1].Points.AddXY(t3LevelLineUpDown.Value, 1);
            levelChart.Series[1].Points.AddXY(t4LevelLineUpDown.Value, 0);

            levelChart.Series[2].Points.Clear();
            levelChart.Series[2].Points.AddXY(s1LevelLineUpDown.Value, 0);
            levelChart.Series[2].Points.AddXY(s2LevelLineUpDown.Value, 1);
            levelChart.Series[2].Points.AddXY(9, 1);

            levelChart.Series[3].Points.Clear();
            levelChart.Series[3].Points.AddXY(currentLevelUpDown.Value, 1);
            levelChart.Series[3].Points.AddXY(currentLevelUpDown.Value, 0);

            consumptionChart.Series[0].Points.Clear();
            consumptionChart.Series[0].Points.AddXY(0.08, 1);
            consumptionChart.Series[0].Points.AddXY(z1ConsLineUpDown.Value, 1);
            consumptionChart.Series[0].Points.AddXY(z2ConsLineUpDown.Value, 0);

            consumptionChart.Series[1].Points.Clear();
            consumptionChart.Series[1].Points.AddXY(t1ConsLineUpDown.Value, 0);
            consumptionChart.Series[1].Points.AddXY(t2ConsLineUpDown.Value, 1);
            consumptionChart.Series[1].Points.AddXY(t3ConsLineUpDown.Value, 1);
            consumptionChart.Series[1].Points.AddXY(t4ConsLineUpDown.Value, 0);

            consumptionChart.Series[2].Points.Clear();
            consumptionChart.Series[2].Points.AddXY(s1ConsLineUpDown.Value, 0);
            consumptionChart.Series[2].Points.AddXY(s2ConsLineUpDown.Value, 1);
            consumptionChart.Series[2].Points.AddXY(0.5, 1);

            consumptionChart.Series[3].Points.Clear();
            consumptionChart.Series[3].Points.AddXY(consumptionUpDown.Value, 1);
            consumptionChart.Series[3].Points.AddXY(consumptionUpDown.Value, 0);

            inflowChart.Series[0].Points.Clear();
            inflowChart.Series[0].Points.AddXY(0.08, 1);
            inflowChart.Series[0].Points.AddXY(z1InflowLineUpDown.Value, 1);
            inflowChart.Series[0].Points.AddXY(z2InflowLineUpDown.Value, 0);

            inflowChart.Series[1].Points.Clear();
            inflowChart.Series[1].Points.AddXY(t1InflowLineUpDown.Value, 0);
            inflowChart.Series[1].Points.AddXY(t2InflowLineUpDown.Value, 1);
            inflowChart.Series[1].Points.AddXY(t3InflowLineUpDown.Value, 1);
            inflowChart.Series[1].Points.AddXY(t4InflowLineUpDown.Value, 0);

            inflowChart.Series[2].Points.Clear();
            inflowChart.Series[2].Points.AddXY(s1InflowLineUpDown.Value, 0);
            inflowChart.Series[2].Points.AddXY(s2InflowLineUpDown.Value, 1);
            inflowChart.Series[2].Points.AddXY(0.5, 1);

            inflowChart.Series[3].Points.Clear();
            inflowChart.Series[3].Points.AddXY(result, 1);
            inflowChart.Series[3].Points.AddXY(result, 0);

            double x = 0.08;
            double h = 0.001;

            inflowChart.Series[4].Points.Clear();
            while (x < 0.5)
            {
                inflowChart.Series[4].Points.AddXY(x, fuzzyLogicAlgorithm.CalculateUnionOfFuzzySets(x));

                x += h;
            }

            fuzzy1Label.Text = fuzzyLogicAlgorithm.RulesBase.Rules[0].Degree.ToString();
            fuzzy2Label.Text = fuzzyLogicAlgorithm.RulesBase.Rules[1].Degree.ToString();
            fuzzy3Label.Text = fuzzyLogicAlgorithm.RulesBase.Rules[2].Degree.ToString();
            fuzzy4Label.Text = fuzzyLogicAlgorithm.RulesBase.Rules[3].Degree.ToString();
            fuzzy5Label.Text = fuzzyLogicAlgorithm.RulesBase.Rules[4].Degree.ToString();
            fuzzy6Label.Text = fuzzyLogicAlgorithm.RulesBase.Rules[5].Degree.ToString();
            fuzzy7Label.Text = fuzzyLogicAlgorithm.RulesBase.Rules[6].Degree.ToString();
            fuzzy8Label.Text = fuzzyLogicAlgorithm.RulesBase.Rules[7].Degree.ToString();
            fuzzy9Label.Text = fuzzyLogicAlgorithm.RulesBase.Rules[8].Degree.ToString();
        }

        private Grade ConvertTextToGrade(string text)
        {
            switch(text)
            {
                case "большой":
                    return Grade.Big;
                case "средний":
                    return Grade.Medium;
                case "малый":
                    return Grade.Small;
            }

            return Grade.Medium;
        }

        private IActivation ConvertTextToActivation(string text)
        {
            switch(text)
            {
                case "min":
                    return new MinActivation();
                case "prod":
                    return new ProdActivation();
                case "average":
                    return new AverageActivation();
            }

            return new MinActivation();
        }

        private IAccumulation ConvertTextToAccumulation(string text)
        {
            switch (text)
            {
                case "макс":
                    return new MaxAccumulation();
                case "алгебраическое":
                    return new AlgebraicAccumulation();
                case "граничное":
                    return new BorderyAccumulation();
                case "драстическое":
                    return new DrasticAccumulation();
            }

            return new MaxAccumulation();
        }

        private IDefuzzification ConvertTextToDefuzzification(string text)
        {
            switch (text)
            {
                case "центр тяжести":
                    return new CenterDefuzzification(0.08, 0.5);
                case "центр площади":
                    return new SquareDefuzzification(0.08, 0.5);
                case "левое модальное":
                    return new LeftDefuzzification(0.08, 0.5);
                case "правое модальное":
                    return new RightDefuzzification(0.08, 0.5);
            }

            return new CenterDefuzzification(0.08, 0.5);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}
