using NUnit.Framework;
using Subscriber;

namespace SubscriberTest
{
    public class Tests
    {
        [Test]
        public void CheckSub1()
        {
            Countdown cnd = new Countdown();

            Subscriber1 Subscriber1 = new Subscriber1(3);
            cnd.AddSub(Subscriber1);

            
            Assert.AreEqual(1, Subscriber1._subNum);
            Assert.AreEqual(3, Subscriber1._delay);
        }

        [Test]
        public void CheckSub2()
        {
            Countdown cnd = new Countdown();

            Subscriber2 Subscriber2 = new Subscriber2(3);
            cnd.AddSub(Subscriber2);


            Assert.AreEqual(2, Subscriber2._subNum);
            Assert.AreEqual(3, Subscriber2._delay);
        }
    }
}