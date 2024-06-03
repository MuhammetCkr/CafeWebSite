using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextWeb.Entity
{
    public class Settings
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string BannerImage { get; set; }

        public string MenuColor { get; set; }
        public string TitleColor { get; set; }
        public string DescriptionColor { get; set; }
        public string PriceColor { get; set; }
        public string IconColor { get; set; }
        public string BackgroundColor { get; set; }
        public string MenuBackgroundColor { get; set; }
        public string CategoryColor { get; set; }
        
        public string MenuFont { get; set; }
        public string DescriptionFont { get; set; }
        public string TitleFont { get; set; }
        public string PriceFont { get; set; }
        public string CategoryFont { get; set; }

    }
}
