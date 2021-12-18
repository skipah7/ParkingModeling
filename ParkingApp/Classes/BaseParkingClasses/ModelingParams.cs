using ParkingApp.Classes.ModelingClasses;
using System.Collections.Generic;

namespace ParkingApp.Classes.BaseParkingClasses
{
    public enum LawTypes
    {
        Uniform,
        Exponential,
        Normal,
        Deterministic,
    }

    public class ModelingParams
    {
        private DistributionsClass distributions;
        private LawTypes flowType;
        private LawTypes parkingType;
        private Dictionary<string, double> flowValues;
        private Dictionary<string, double> parkingValues;

        public double lightToHeavyRatio;
        public double lightCarProbability;
        public double heavyCarProbability;

        public double appearanceInterval
        {
            get => getInterval(this.flowType, this.flowValues);
        }
        public double parkingInterval
        {
            get => getInterval(this.parkingType, this.parkingValues);
        }


        public ModelingParams(
            LawTypes flowType, 
            LawTypes parkingType, 
            Dictionary<string, double> flowValues, 
            Dictionary<string, double> parkingValues,
            double lightToHeavyRatio,
            double lightCarProbability,
            double heavyCarProbability
        )
        {
            this.distributions = new DistributionsClass();

            this.flowType = flowType;
            this.parkingType = parkingType;

            this.flowValues = flowValues;
            this.parkingValues = parkingValues;

            this.lightToHeavyRatio = lightToHeavyRatio;
            this.lightCarProbability = lightCarProbability;
            this.heavyCarProbability = heavyCarProbability;
        }

        private double getInterval(LawTypes lawType, Dictionary<string, double> values)
        {
            if (lawType == LawTypes.Deterministic) {
                return values["interval"];
            }
            if (lawType == LawTypes.Uniform)
            {
                return this.distributions.generateUniformValue(values["a"], values["b"]);
            }
            if (lawType == LawTypes.Exponential)
            {
                return this.distributions.generateExponentialValue(values["lambda"]);
            }
            if (lawType == LawTypes.Normal)
            {
                return this.distributions.generateNormalValue(values["MX"], values["DX"]);
            }

            return 0;
        }

    }
}
