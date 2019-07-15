using FlightJournal.Web.Translations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FlightJournal.Web.Models
{
    public class AirspaceInfo
    {

        private DateTime m_Date;

        [Key]
        public int Id { get; set; }
        public bool isOpen { get; set; }

        [LocalizedDisplayName("Pilot")]
        [Required]
        public int PilotId { get; set; }
        public Pilot Pilot { get; set; }

        [LocalizedDisplayName("Date")]
        [DataType(DataType.Date)]
        public DateTime Date
        {
            get
            {
                return m_Date;
            }
            set
            {
                if (value != value.ToUniversalTime())
                {
                    m_Date = new DateTime(value.Year, value.Month, value.Day, 0, 0, 0);
                }
                else
                    m_Date = value;

                if (m_Date.TimeOfDay != new TimeSpan(0, 0, 0))
                    throw new ArgumentOutOfRangeException("DateTime is not a UTC Date set at 00:00:00 must be submitted, date: " + m_Date.ToString() + " value:" + value.ToString() + " universaltime: " + value.ToUniversalTime().ToString());
            }
        }
        public int Altitude { get; set; }
        public int FlightLevel { get; set; }
    }
}