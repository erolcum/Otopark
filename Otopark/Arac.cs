using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otopark
{
    public class Arac
    {
        public Arac()
        {
            Giris = DateTime.Now;
        }
        public string Plaka { get; set; }
        public AracTip Tip { get; set; }
        public bool Kontak { get; set; }
        public bool Abone { get; set; }
        public DateTime Giris { get; set; }
        public DateTime Cikis { get; set; }
        public decimal Ucret
        {
            get 
            {
                decimal toplam = Tip.Fiyat * (Sure-1) + Tip.Fiyat * 2;
                if (Abone) toplam *= 0.8m;
                return toplam;
            }
        
        }

        public int Sure
        {
            get 
            {
                TimeSpan fark = Cikis - Giris;
                if (fark - TimeSpan.FromHours((int)fark.TotalHours) > TimeSpan.Zero)
                    fark = fark.Add(TimeSpan.FromHours(1));

                return (int) fark.TotalHours; 
            }
        }
        public override string ToString()
        {
            string abone = Abone ? "Abone" : "Abone Değil";
            string kontak = Kontak ? "Kontak Var" : "Kontak Yok";
            return $"{Plaka}-{Tip.Adi}-{abone}-{kontak}"; 
        }

    }

    public class AracTip 
    {
        public string Adi { get; set; }
        public decimal Fiyat { get; set; }
        public override string ToString()
        {
            return Adi; 
        }
    }
}
