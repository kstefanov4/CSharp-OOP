using NavalVessels.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace NavalVessels.Models
{
    public class Submarine : Vessel, ISubmarine
    {
        private const double InitialArmorThickness = 200;
        private bool submergeMode = false;
        public Submarine(string name, double mainWeaponCaliber, double speed) 
            : base(name, mainWeaponCaliber, speed, InitialArmorThickness)
        {
        }

        public bool SubmergeMode => this.submergeMode;

        public void ToggleSubmergeMode()
        {
            if (this.SubmergeMode == false)
            {
                this.submergeMode = true;
                this.MainWeaponCaliber += 40;
                this.Speed -= 4;
            }
            else
            {
                this.submergeMode = false;
                this.MainWeaponCaliber -= 40;
                this.Speed += 4;
            }
        }
        public override void RepairVessel()
        {
            this.ArmorThickness = InitialArmorThickness;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine($" *Submerge mode: {(SubmergeMode == true ? "ON" : "OFF")}");
            return sb.ToString().TrimEnd();
        }
    }
}
