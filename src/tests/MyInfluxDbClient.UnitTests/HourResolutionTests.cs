using System;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace MyInfluxDbClient.UnitTests
{
    [TestFixture]
    public class HourResolutionTests : UnitTestsOf<HourResolution>
    {
        public HourResolutionTests()
        {
            SUT = new HourResolution();
        }

        [Test]
        public void NanosecondsFrom_Should_return_nanoseconds_by_multiplying_100_to_reminders_of_ticks_subtracted_by_modulus_36000000000()
        {
            var ts = TimeStamp.Now();

            var ns = SUT.NanosecondsFrom(ts);

            ns.Should().Be((ts.Ticks - ts.Ticks % 36000000000) * 100);
        }

        [Test]
        public void NanosecondsFrom_Should_return_value_with_eleven_ending_zeroes()
        {
            var dt = new DateTime(635843473895094535);
            var ts = TimeStamp.From(dt);

            var ns = SUT.NanosecondsFrom(ts);

            var s = string.Join(string.Empty, ns.ToString().Reverse());
            s.Should().StartWith("00000000000");
            s.Skip(11).First().Should().NotBe('0');
        }
    }
}