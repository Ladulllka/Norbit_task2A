using Microsoft.AspNetCore.Mvc;

namespace IMB
{
    public class BMI
    {
       public void AddHeight(double Add){
            Height = Add;
        }
         public void AddWeigth(double Add){
            Weight=Add;
        }
        public double ShowWeight()
        {
            return Weight;
        }
        public double ShowHeight()
        {
            return Height;
        }
        public void AddIndexBody(double H,double W)
        {
            IndexBody = W /(H*H) ;
        }
        public double ShowIndexBody()
        {
            return IndexBody;
        }
        public void AddDescription(string Disc)
        {
            IndexDescriprion= Disc;
        }
        public string ShowDescription()
        {
            return IndexDescriprion;
        }

        private double Height,Weight,IndexBody;
        private string IndexDescriprion="";
    }

  



}   