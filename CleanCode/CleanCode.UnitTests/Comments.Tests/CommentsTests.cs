using CleanCode.Comments;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCode.UnitTests.Comments.Tests
{
    [TestFixture]
    class CommentsTests
    {
        [Test]
        public void GetCustomers_WhenCalled_ThrowNotImplementedException()
        {
            //Arrange
            var commentsClassObject = new CleanCode.Comments.Comments();

            //Act - Assert
            Assert.That(() => commentsClassObject.GetCustomers(1), Throws.InstanceOf<NotImplementedException>());
        }


    }
}
