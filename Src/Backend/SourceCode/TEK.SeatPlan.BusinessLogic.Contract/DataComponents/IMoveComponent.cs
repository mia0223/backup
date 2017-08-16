using TEK.SeatPlan.Dto;

namespace TEK.SeatPlan.BusinessLogic.Contract
{
    public interface IMoveComponent
    {
        Entity.Seat CreateTransitSeat();
        void Move(Dto.SeatPair seatPair);
        void Move(TEK.SeatPlan.BusinessLogic.SeatPair seatPair, bool isAutoTransit);
        SeatPair MoveValidate(Dto.SeatPair seatPair);
    }
}