using System;
using NUnit.Framework;
using ALGA;

namespace ALGA_test
{
    [Category("Abstract Syntax Tree")]
    public class AbstractSyntaxTreeTest
    {
        private Operand zeven_keer_vier_plus_vijf;

        [SetUp]
        public void Setup()
        {
            Number vier = new Number(4);
            Number vijf = new Number(5);
            Operand vier_plus_vijf = new Operand('+', vier, vijf);

            Number zeven = new Number(7);
            zeven_keer_vier_plus_vijf = new Operand('*', vier_plus_vijf, zeven);
        }

        [Test]
        public void AbstractSyntaxTreeEvaluate()
        {
            Assert.That(zeven_keer_vier_plus_vijf.evaluate(), Is.EqualTo(63));
        }

        [Test]
        public void AbstractSyntaxTreeToString()
        {
            Assert.That(zeven_keer_vier_plus_vijf.ToString(), Is.EqualTo("((4+5)*7)"));
        }
    }
}
