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
            BMI Index = new BMI(); // �������� ���������� ������
            bool ValidWeight = false;// ������������ ���������� ��� ���������
            bool ValidHeight = false;

            Index.AddHeight(height);//���������� � ��������� ������
            Index.AddWeigth(weight);
            Index.AddIndexBody(Index.ShowHeight(), Index.ShowWeight());

            if (Index.ShowIndexBody() <= 16) Index.AddDescription("���������� ������� ����� ����");

            if (Index.ShowIndexBody() > 16 && Index.ShowIndexBody() < 18.5) Index.AddDescription("������������� (�������) ����� ����");

            if (Index.ShowIndexBody() >= 18.5 && Index.ShowIndexBody() < 25) Index.AddDescription("�����");

            if (Index.ShowIndexBody() >= 25 && Index.ShowIndexBody() < 30) Index.AddDescription("���������� ����� ���� (������������)");

            if (Index.ShowIndexBody() >= 30 && Index.ShowIndexBody() < 35) Index.AddDescription("�������� 1 �������");

            if (Index.ShowIndexBody() >= 35 && Index.ShowIndexBody() < 40) Index.AddDescription("�������� 2 �������");

            if (Index.ShowIndexBody() >= 40) Index.AddDescription("�������� 3 �������");


            if ((Index.ShowWeight() > 3) & (Index.ShowWeight() <= 635)) //�������� �� ���������� ����
            {
                ValidWeight = true;
            }
            else ValidWeight = false;

            if ((Index.ShowHeight() > 0.45) & (Index.ShowHeight() <= 2.72)) //�������� �� ���������� �����
            {
                ValidHeight = true;
            }
            else ValidHeight = false;

            if (ValidHeight && ValidWeight)
            {
                return "��� ������ ����� ���� ����� = "+(Math.Round(Index.ShowIndexBody(),2)).ToString()+ ". C����������� ����� ������ �������� � ��� ������ - "+Index.ShowDescription();

            }

            if (ValidHeight && !ValidWeight)
            {
                return ("��������� ������������ ��������� ����");
            }

            if (!ValidHeight && ValidWeight)
            {
                return ("��������� ������������ ��������� �����");
            }

            if (!ValidHeight && !ValidWeight)
            {
                return ("��������� ������������ ���� ������");
            }

            return ("");
        }
    }
}