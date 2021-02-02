using System;

namespace ValutaConvert
{
    public class Converter
    {
        const double SWEtoDK = 0.7041;
        const double DKtoSWE = 1.0 / 0.7041;

        public static double TilSvenskeKroner(double danskeKroner)
        {
            return danskeKroner * DKtoSWE;
        }

        public static double TilDanskeKroner(double svenskeKroner)
        {
            return svenskeKroner * SWEtoDK;
        }
    }
}
