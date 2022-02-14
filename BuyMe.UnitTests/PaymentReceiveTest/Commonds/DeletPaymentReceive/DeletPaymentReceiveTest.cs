using BuyMe.Application.Common.Exceptions;
using BuyMe.Application.PaymentReceive.Commonds.DeletPaymentReceive;
using BuyMe.UnitTests.Common;
using Shouldly;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using static BuyMe.Application.PaymentReceive.Commonds.DeletPaymentReceive.DeletPaymentReceiveCommond;

namespace BuyMe.UnitTests.PaymentReceiveTest.Commonds.DeletPaymentReceive
{
    public class DeletPaymentReceiveTest: CommandTestBase
    {
        private readonly DeletPaymentReceiveCommondHandler _sut;
        public DeletPaymentReceiveTest()
        {
            this._sut = new DeletPaymentReceiveCommondHandler(buyMeDbContext);
        }
        [Fact]
        public async Task DeletePaymentReceive_ValidId_Unit()
        {
            var validId = 1;
            var commond = new DeletPaymentReceiveCommond { PaymentReceiveId = validId };
            await _sut.Handle(commond, CancellationToken.None);
            var entity = await buyMeDbContext.PaymentReceives.FindAsync(validId);
            entity.ShouldBeNull();
        }
        [Fact]
        public async Task DeletePaymentReceive_NotValidId_ThrowNotFoundException()
        {
            var validId = 54;
            var commond = new DeletPaymentReceiveCommond { PaymentReceiveId = validId };
            await Assert.ThrowsAsync<NotFoundException>(() => _sut.Handle(commond, CancellationToken.None));


        }
    }
}
