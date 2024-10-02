using System;
using System.ComponentModel;

class Program
{
    static void Main(string[] args)
    {
     
     Costume nurse = new();
     nurse.headWear = "Face mask";
     nurse.handWear = "Nitrile Gloves";
     nurse.footWear = "Orthopedic sneakers";
     nurse.torsoWear = "Scrubs";
     nurse.legWear = "Scrubs";
     nurse.extraWear = "Stethoscope";

     Costume detective = new();
     detective.headWear = "Fedora";
     detective.handWear = "Leather gloves";
     detective.footWear = "Loafers";
     detective.torsoWear = "Trenchcoat";
     detective.legWear = "Slacks";
     detective.extraWear = "Magnifying glass";

     Costume rancher = new();
     rancher.headWear = "Cowboy hat";
     rancher.handWear = "Work gloves";
     rancher.footWear = "Cowboy boots";
     rancher.torsoWear = "Flannel shirt";
     rancher.legWear = "Jeans";
     rancher.extraWear = "Lasso";

    nurse.ShowWardrobe();
    detective.ShowWardrobe();
    rancher.ShowWardrobe();

    }
}