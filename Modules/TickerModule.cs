
using Gatto.AspNetCore.ApiHandlers;
using Gatto.AspNetCore.ApiRequests;
using SBT.Shared.DAO;

namespace MSC_55.Modules
{
    public static class TickerModule
    {
        static ListRequestHandler<ListRequest> TICKER_LIST_HANDLER = new ListRequestHandler<ListRequest>()
                .AddDefaultFilterDecorator()
                .AddDefaultSortDecorator()
                .AddView<CpTickerObject, ListRequest>("default",
                        (request, query) => query.Select(CpTicker._ALL_));

        public static WebApplication MapTickerApi(this WebApplication app)
        {
            var tickerEnpoints = app.MapGroup("api/ticker");

            tickerEnpoints.MapPost("/list", async (ListRequest request) => await TICKER_LIST_HANDLER.Handle(request));

            return app;
        }
    }
}
