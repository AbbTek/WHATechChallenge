using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WHA.Core.Domain;

namespace WHA.Core.Business
{
    public static class CsvFilelUtil
    {
        public static IList<Bet> ReadFile(string path, BetType type)
        {
            var list = new List<Bet>();
            var lines = File.ReadAllLines(path);

            foreach (var line in lines)
            {
                var values = line.Split(new char[] { ',' });
                int customerID;
                int eventID;
                int participantID;
                double stake;
                double win;

                if (int.TryParse(values[0], out customerID) &&
                    int.TryParse(values[1], out eventID) &&
                    int.TryParse(values[2], out participantID) &&
                    double.TryParse(values[3], out stake) &&
                    double.TryParse(values[4], out win))
                {
                    list.Add(new Bet()
                    {
                        CustomerID = customerID,
                        ParticipantID = participantID,
                        EventID = eventID,
                        Type = type,
                        Stake = stake,
                        Win = win
                    });
                }
            }
            return list;
        }
    }
}
