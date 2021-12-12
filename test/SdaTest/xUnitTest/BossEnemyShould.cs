using Sda.Application.xUnitTest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace SdaTest
{
    [Trait("Category", "Enemy")]
    public class BossEnemyShould : IDisposable
    {
        private readonly Patient _patient;
        private readonly ITestOutputHelper _output;
        public BossEnemyShould(ITestOutputHelper output)
        {
            _output = output;
            _output.WriteLine("正在创建新的玩家角色");
            _patient = new Patient()
            {
                FirstName = "cheng",
                LastName ="lei"
            };
        }

        [Fact]
       
        public void HaveCorrectPower()
        {
            Assert.Equal(3, 3);
        }

        [Theory]
        //[InlineData(0,100)]
        //[InlineData(1,101)]
        //[InlineData(-1,99)]

       // [MemberData(nameof(TestData.Data),MemberType = typeof(TestData))]
        [TestData2]
        public void TakeDamage(int damage, int expectedHealth)
        {
            var result= _patient.Add(damage);
            Assert.Equal(expectedHealth, result);
        }


        public void Dispose()
        {
            _output.WriteLine($"正在清理玩家{_patient.FullName}");
        }

    }
}
