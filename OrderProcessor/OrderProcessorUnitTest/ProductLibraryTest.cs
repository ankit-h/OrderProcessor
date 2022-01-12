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
            var procuderFactory = FactoryProducer.GetProductFactory(true);

            //// Assert
            procuderFactory.GetType().Should().Be(typeof(NonPhysicalProductFactory));
        }
    }
}
