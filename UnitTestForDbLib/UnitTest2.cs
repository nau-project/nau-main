using System;
using System.Collections;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using DataBaseLibrary.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace UnitTestForDbLib
{
    /// <summary>
    /// Сводное описание для UnitTest2
    /// </summary>
    [TestClass]
    public class UnitTest2
    {
        /*TestEntityRepository<Student> testEntityRepository = new StudentRepository(new List<Student>()
                                                                                      {
                                                                                          new Student(),
                                                                                          new Student()
                                                                                      });

        Guid id = Guid.NewGuid();
        Guid id2 = Guid.NewGuid();
        Guid id3 = Guid.NewGuid();
        public UnitTest2()
        {
            //
            // TODO: добавьте здесь логику конструктора
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Получает или устанавливает контекст теста, в котором предоставляются
        ///сведения о текущем тестовом запуске и обеспечивается его функциональность.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Дополнительные атрибуты тестирования
        //
        // При написании тестов можно использовать следующие дополнительные атрибуты:
        //
        // ClassInitialize используется для выполнения кода до запуска первого теста в классе
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // ClassCleanup используется для выполнения кода после завершения работы всех тестов в классе
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // TestInitialize используется для выполнения кода перед запуском каждого теста 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // TestCleanup используется для выполнения кода после завершения каждого теста
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void TestList()
        {
            Assert.IsTrue(testEntityRepository.GetAll().Count == 2);
        }

        [TestMethod]
        public void TestMethodInsert()
        {
            testEntityRepository.Insert(new Student());
            Assert.IsTrue(testEntityRepository.GetAll().Count == 3);
        }

        [TestMethod]
        public void TestMethodInsertArray()
        {
            IEnumerable<Student> Students = new Student[] { new Student(), new Student() };
            testEntityRepository.Insert(Students);
            Assert.IsTrue(testEntityRepository.GetAll().Count == 4);
        }

        [TestMethod]
        public void TestMethodDelete()
        {
            Student Student = new Student();
            Student.Id = id;
            
            testEntityRepository.Insert(Student);
            Assert.IsTrue(testEntityRepository.GetAll().Count == 3);

            Student Student2 = new Student();
            Student2.Id = id;
            testEntityRepository.Delete(Student2);
            Assert.IsTrue(testEntityRepository.GetAll().Count == 2);
        }

        [TestMethod]
        public void TestMethodDeleteArray()
        {
            IEnumerable<Student> Students = new Student[]
                                        {
                                            new Student() { Id = id },
                                            new Student() { Id = id2 }
                                        };
            testEntityRepository.Insert(Students);
            Assert.IsTrue(testEntityRepository.GetAll().Count == 4);

            IEnumerable<Student> Students2 = new Student[]
                                         {
                                             new Student() { Id = id },
                                             new Student() { Id = id2 }
                                         };
            testEntityRepository.Delete(Students2);
            Assert.IsTrue(testEntityRepository.GetAll().Count == 2);
        }

        [TestMethod]
        public void TestMethodGetById()
        {
            Student[] Students = new Student[]
                             {
                                 new Student(){Id = id},
                                 new Student(){Id = id2}
                             };

            testEntityRepository.Insert(Students);
            Assert.IsNotNull(testEntityRepository.GetById(id2));
        }

        [TestMethod]
        public void TestMethodDeleteById()
        {
            Student[] Students = new Student[]
                             {
                                 new Student(){Id = id},
                                 new Student(){Id = id2}
                             };
            
            testEntityRepository.Insert(Students);
            testEntityRepository.Delete(id);
            Assert.IsTrue(testEntityRepository.GetAll().Count == 3);
        }*/
    }
}
