using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApprovalTests;
using ApprovalTests.Reporters;
using NUnit.Framework;

namespace Trivia.Tests
{
    [TestFixture]
    internal class GoldenMasterShould
    {
        [Test]
        [UseReporter(typeof(DiffReporter))]
        public void NotChange()
        {
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);
            GameRunner.Main(null);
            Approvals.Verify(stringWriter);

        }
    }
}
