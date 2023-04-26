using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IMB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace HelloWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BodyMassIndexController : ControllerBase
    {

        [HttpGet]

        public string GetBMI(double weight, double height)
        {
            BMI Index = new BMI(); // создание экземпляра класса
            bool ValidWeight = false;// иницализация переменных для валидации
            bool ValidHeight = false;

            Index.AddHeight(height);//добавление в экземпляр данных
            Index.AddWeigth(weight);
            Index.AddIndexBody(Index.ShowHeight(), Index.ShowWeight());

            if (Index.ShowIndexBody() <= 16) Index.AddDescription("Выраженный дефицит массы тела");

            if (Index.ShowIndexBody() > 16 && Index.ShowIndexBody() < 18.5) Index.AddDescription("Недостаточная (дефицит) масса тела");

            if (Index.ShowIndexBody() >= 18.5 && Index.ShowIndexBody() < 25) Index.AddDescription("Норма");

            if (Index.ShowIndexBody() >= 25 && Index.ShowIndexBody() < 30) Index.AddDescription("Избыточная масса тела (предожирение)");

            if (Index.ShowIndexBody() >= 30 && Index.ShowIndexBody() < 35) Index.AddDescription("Ожирение 1 степени");

            if (Index.ShowIndexBody() >= 35 && Index.ShowIndexBody() < 40) Index.AddDescription("Ожирение 2 степени");

            if (Index.ShowIndexBody() >= 40) Index.AddDescription("Ожирение 3 степени");


            if ((Index.ShowWeight() > 3) & (Index.ShowWeight() <= 635)) //проверка на валидность веса
            {
                ValidWeight = true;
            }
            else ValidWeight = false;

            if ((Index.ShowHeight() > 0.45) & (Index.ShowHeight() <= 2.72)) //проверка на валидность роста
            {
                ValidHeight = true;
            }
            else ValidHeight = false;

            if (ValidHeight && ValidWeight)
            {
                return "Ваш индекс массы тела равен = "+(Math.Round(Index.ShowIndexBody(),2)).ToString()+ ". Cоответствие между массой человека и его ростом - "+Index.ShowDescription();

            }

            if (ValidHeight && !ValidWeight)
            {
                return ("Проверьте корректность введённого веса");
            }

            if (!ValidHeight && ValidWeight)
            {
                return ("Проверьте корректность введённого роста");
            }

            if (!ValidHeight && !ValidWeight)
            {
                return ("Проверьте корректность всех данных");
            }

            return ("");
        }
    }
}