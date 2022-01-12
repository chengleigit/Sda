using Sda.Application.xUnitTest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SdaTest
{
    public class PatientShould
    {
        private readonly Patient _patient;
        private readonly Plumber _plumber;
        public PatientShould()
        {
            _patient = new Patient()
            {
                FirstName = "cheng",
                LastName = "lei"
            };

            _plumber = new Plumber();
        }

        [Fact]
        public void CalculateFullName()
        {
            Assert.True(_patient.IsNew);
            Assert.Equal("cheng Lei", _patient.FullName, true); //测试string是否相等,病忽略大小写
            Assert.StartsWith("cheng", _patient.FullName);
            Assert.EndsWith("lei", _patient.FullName);
            Assert.Contains("cheng", _patient.FullName);
            //Assert.Matches("[A-Z]{1}{a-z}+ [A-Z]{1}[a-z]+", p.FullName);
        }

        [Fact]
        public void TestNumber()
        {
            Assert.Equal(5.0, _patient.BloodSugar); //测试数值相等
            _patient.HaveDinner();
            Assert.InRange(_patient.BloodSugar, 5, 15); //测试数值的范围
            Assert.Equal(66.667, _plumber.Salary, precision: 3);
        }
      
        [Fact]
        public void TestName() 
        {
            Assert.Null(_plumber.Name);
            _plumber.Name = "chenglei";
            Assert.NotNull(_plumber.Name); 
            Assert.Contains("螺丝刀", _plumber.Tools); //测试集合是否包含某个元素.
            Assert.DoesNotContain("键盘", _plumber.Tools);//测试集合是否不包含某个元素.
            Assert.Contains(_plumber.Tools, t => t.Contains("螺丝刀")); //测试一下集合中是否包含符合某个条件的元素

            //比较集合相等
            var expectedTools = new[]{"螺丝刀","扳子","钳子"};
            Assert.Equal(expectedTools, _plumber.Tools);

            //测试集合中的每一个元素
            Assert.All(_plumber.Tools, t => Assert.False(string.IsNullOrEmpty(t)));
        }

        [Fact]
        public void TestObj()
        {
            var factory = new WorkerFactory();
            Worker worker = factory.Create("Nick");
            Assert.IsType<Plumber>(worker); //判断是否是某个类型 
            Assert.IsNotType<Programmer>(worker);

            Worker worker1 = factory.Create("Nick", isProgrammer: true);
            Programmer programmer = Assert.IsType<Programmer>(worker1);
            Assert.Equal("Nick", programmer.Name);
            
            Assert.IsAssignableFrom<Worker>(worker1); //判断父类

            //判断两个引用是否指向不同的实例 Assert.NotSame(a, b):
            var p1 = factory.Create("Nick");
            var p2 = factory.Create("Nick");
            Assert.NotSame(p1, p2);

            //异常
            ArgumentNullException ex = Assert.Throws<ArgumentNullException>(() => factory.Create(null));
            Assert.Equal("name", ex.ParamName);
        }


        [Fact]
        public void RaiseSleptEvent()
        {
            //事件
            var p = new Patient();
            Assert.Raises<EventArgs>(
                handler => p.PatientSlept += handler,
                handler => p.PatientSlept -= handler,
                () => p.Sleep());
        }

    }
}
