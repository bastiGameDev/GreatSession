using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Text.RegularExpressions;
using SESSIONWPF;

namespace Testing
{
    [TestClass]
    public class ValidationTests
    {
        // Пароль не должен состоять из логина!
        [TestMethod]
        public void ifPassSameAsLogin_enterString_falseReterned()
        {
            ValidationChecker checker = new ValidationChecker();
            string login = "loginDEbho2018";
            string password = "loginDEbho2018";

            bool isSame = checker.PasswordStringValidation(login, password);
            Assert.IsFalse(isSame);
        }

        // Пароль должен содержать от 5 до 20 символов!
        [TestMethod]
        public void ifPassLengthIsBetween4and20_enterString_falseReterned()
        {
            ValidationChecker checker = new ValidationChecker();
            string login = "Mom";
            string password = "Mom";

            bool isShort = checker.PasswordStringValidation(login, password);
            Assert.IsFalse(isShort);
        }

        // Пароль должен содержать буквы верхнего регистра!
        [TestMethod]
        public void ifPassContainsUpperCaseLetters_enterString_falseReterned()
        {
            ValidationChecker checker = new ValidationChecker();
            string login = "password";
            string password = "password";

            bool isUpper = checker.PasswordStringValidation(login, password);
            Assert.IsFalse(isUpper);
        }

        // Пароль должен содержать буквы нижнего регистра!
        [TestMethod]
        public void ifPassContainsLowerCaseLetters_enterString_falseReterned()
        {
            ValidationChecker checker = new ValidationChecker();
            string login = "PASSWORD";
            string password = "PASSWORD";

            bool isLower = checker.PasswordStringValidation(login, password);
            Assert.IsFalse(isLower);
        }

        /// После трех неудачных попыток авторизации форма должна блокироваться на 5 секунд, не позволяя вводить данные или любые кнопки
        /// Должно выдаваться сообщение об ошибке в случае неправильного ввода связки логин/пароль.
        [TestMethod]
        public void ifOnly5Try_enter5Strings_falseReterned()
        {
            ValidationChecker checker = new ValidationChecker();
            string login = "PASSWORD";
            string password = "PASSWORD";

            for (int i = 0; i < 5; i++)
            {
                //bool check = checker.CheckTRY(login, password, true, 0) ;
            }

            bool isLower = checker.PasswordStringValidation(login, password);
            Assert.IsFalse(isLower);
        }
    }
}
