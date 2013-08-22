using System;
using ChangeMachineProblem;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// ReSharper disable InconsistentNaming

namespace ChangeMachineProblemTests
{
    [TestClass]
    public class ChangeMachineTests
    {
        private ChangeMachine _changeMachine;

        [TestInitialize]
        public void Initialize()
        {
            _changeMachine = new ChangeMachine();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void It_should_not_accept_less_than_two_cents()
        {
            _changeMachine.MakeChange(0.01);
        }

        [TestMethod]
        [ExpectedException(typeof (ArgumentException))]
        public void It_should_not_accept_more_than_twenty_dollars()
        {
            _changeMachine.MakeChange(20.01);
        }

        [TestMethod]
        public void It_should_return_five_pennies_for_five_cents()
        {
            var result = _changeMachine.MakeChange(0.05);
            Assert.AreEqual(5, result[0.01]);
        }

        [TestMethod]
        public void It_should_return_one_nickel_and_two_pennies_for_seven_cents()
        {
            var result = _changeMachine.MakeChange(0.07);
            Assert.AreEqual(1, result[0.05]);
            Assert.AreEqual(2, result[0.01]);
        }

        [TestMethod]
        public void It_should_return_one_dime_one_nickel_and_two_pennies_for_seventeen_cents()
        {
            var result = _changeMachine.MakeChange(0.17);
            Assert.AreEqual(1, result[0.10]);
            Assert.AreEqual(1, result[0.05]);
            Assert.AreEqual(2, result[0.01]);
        }

        [TestMethod]
        public void It_should_return_one_quarter_one_dime_one_nickel_and_one_penny_for_fourty_one_cents()
        {
            var result = _changeMachine.MakeChange(0.41);
            Assert.AreEqual(1, result[0.25]);
            Assert.AreEqual(1, result[0.10]);
            Assert.AreEqual(1, result[0.05]);
            Assert.AreEqual(1, result[0.01]);
        }

        [TestMethod]
        public void It_should_return_one_dollar_two_times_and_three_pennies_for_one_dollar_and_twenty_three_cents()
        {
            var result = _changeMachine.MakeChange(1.23);
            Assert.AreEqual(1, result[1.00]);
            Assert.AreEqual(2, result[0.10]);
            Assert.AreEqual(3, result[0.01]); 
        }

        [TestMethod]
        public void It_should_return_one_five_and_three_ones_for_eight_dollars()
        {
            var result = _changeMachine.MakeChange(8.00);
            Assert.AreEqual(1, result[5.00]);
            Assert.AreEqual(3, result[1.00]);
        }

        [TestMethod]
        public void It_should_return_one_ten_one_five_and_two_ones_for_seventeen_dollars()
        {
            var result = _changeMachine.MakeChange(17.00);
            Assert.AreEqual(1, result[10.00]);
            Assert.AreEqual(1, result[5.00]);
            Assert.AreEqual(2, result[1.00]);
        }

        [TestMethod]
        public void It_should_return_two_tens_for_twenty_dollars()
        {
            var result = _changeMachine.MakeChange(20.00);
            Assert.AreEqual(2, result[10.00]);
        }

        [TestMethod]
        public void It_should_return_two_dimes_one_nickel_and_a_penny_for_twenty_six_cents_if_a_dime_is_requested()
        {
            var result = _changeMachine.MakeChange(0.26, 0.10);
            Assert.AreEqual(2, result[0.10]);
            Assert.AreEqual(1, result[0.05]);
            Assert.AreEqual(1, result[0.01]);
        }
    }
}

// ReSharper restore InconsistentNaming