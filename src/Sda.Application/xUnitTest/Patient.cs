using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sda.Application.xUnitTest
{
    public class Patient
    {
        public Patient()
        {
            IsNew = true;
            _bloodSugar = 5.0f; 
        }

        public void Sleep()
        {
            OnPatientSlept();
        }

        public event EventHandler<EventArgs> PatientSlept;

        protected virtual void OnPatientSlept()
        {
            PatientSlept?.Invoke(this, EventArgs.Empty);
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}";
        public int HeartBeatRate { get; set; }
        public bool IsNew { get; set; }

        private float _bloodSugar;
        public float BloodSugar
        {
            get { return _bloodSugar; }
            set { _bloodSugar = value; }
        }

        public void IncreaseHeartBeatRate()
        {
            HeartBeatRate = CalculateHeartBeatRate() + 2;
        }

        private int CalculateHeartBeatRate()
        {
            var random = new Random();
            return random.Next(1, 100);
        }

        public void HaveDinner()
        {
            var random = new Random();
            _bloodSugar += (float)random.Next(1, 1000) / 100; //  应该是1000
        }

        public int Add(int num1) 
        {
            return num1 + 100;
        }
    }


    public abstract class Worker
    {
        public string Name { get; set; }

        public abstract double TotalReward { get; }
        public abstract double Hours { get; }
        public double Salary => TotalReward / Hours;
        public List<string> Tools { get; set; }
    }

    public class Plumber : Worker
    {
        public Plumber()
        {
            Tools = new List<string>()
            {
                "螺丝刀",
                "扳子",
                "钳子"
            };
        }
        public override double TotalReward => 200;
        public override double Hours => 3;
    }

    public class Programmer : Worker
    {
        public override double TotalReward => 1000;
        public override double Hours => 3.5;
    }

    public class WorkerFactory
    {
        public Worker Create(string name, bool isProgrammer = false)
        {
            if (name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }
            if (isProgrammer)
            {
                return new Programmer { Name = name };
            }
            return new Plumber { Name = name };
        }
    }

   
}
