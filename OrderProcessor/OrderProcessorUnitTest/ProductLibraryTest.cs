using FluentAssertions;
using ProductLibrary;
using System;
using Xunit;

namespace OrderProcessorUnitTest
{
    public class ProductLibraryTest
    {
        [Fact]
        public void FactoryProducer_ForPhysicalProducer_ReturnsPhysicalProducerFactory()
        {
            //// Arange

            //// Act
            var procuderFactory = FactoryProducer.GetProductFactory(true);

            //// Assert
            procuderFactory.GetType().Should().Be(typeof(PhysicalProductFactory));
        }

        [Fact]
        public void FactoryProducer_ForNonPhysicalProducer_ReturnsNonPhysicalProducerFactory()
        {
            //// Arange

            //// Act
            var procuderFactory = FactoryProducer.GetProductFactory(false);

            //// Assert
            procuderFactory.GetType().Should().Be(typeof(NonPhysicalProductFactory));
        }

        [Fact]
        public void PhysicalProducer_ForBookInput_Returns3ActionCounts()
        {
            //// Arange

            //// Act
            var procuderFactory = FactoryProducer.GetProductFactory(true);
            var bookProduct =  procuderFactory.GetProduct(ProductType.Book, "Sample Book");

            //// Assert
            bookProduct.ActionCount.Should().Be(3);
        }

        [Fact]
        public void NonPhysicalProducer_ForRandomVideoInput_Returns1ActionCounts()
        {
            //// Arange

            //// Act
            var procuderFactory = FactoryProducer.GetProductFactory(false);
            var bookProduct = procuderFactory.GetProduct(ProductType.Video, "Sample Video");

            //// Assert
            bookProduct.ActionCount.Should().Be(1);
        }


        [Fact]
        public void NonPhysicalProducer_ForLearningToSiVideoInput_Returns2ActionCounts()
        {
            //// Arange

            //// Act
            var procuderFactory = FactoryProducer.GetProductFactory(false);
            var bookProduct = procuderFactory.GetProduct(ProductType.Video, "learning to ski");

            //// Assert
            bookProduct.ActionCount.Should().Be(2);
        }

        [Fact]
        public void PhysicalProducer_ForVideoInput_ThrowsException()
        {
            //// Arange

            //// Act
            var procuderFactory = FactoryProducer.GetProductFactory(true);
           Action act = ()=> procuderFactory.GetProduct(ProductType.Video, "Sample Book");

            //// Assert
            act.Should().Throw<InvalidOperationException>();
        }


    }
}
