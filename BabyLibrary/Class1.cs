using System;

namespace BabyLibrary
{
    public class BabyCool
    {


        public static string AlarmBreath(int breath)
        {
            if (breath > 18)
            {
                return "kritisk høj";
            }

            
            if (breath < 12)
            {
                return "kritisk lav";
            }

            else
            {
                return "normal";
            }
        }

        public static bool AlarmCry(int cry)
        {
            if (cry == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
