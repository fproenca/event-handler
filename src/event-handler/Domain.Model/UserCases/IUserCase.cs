using System;
using System.Collections.Generic;
using System.Text;

namespace event_handler.Domain.Model.UserCases
{
    public interface IUserCase<T, in I, out O>
    {
        O Execute(I imput);
    }

    public interface IUserCase<T, in I1, in I2, out O>
    {
        O Execute(I1 imput1, I2 imput2);
    }

    public interface IUserCase<T, in I1, in I2, in I3, out O>
    {
        O Execute(I1 imput1, I2 imput2, I3 imput3);
    }
    public interface IUserCase<T, in I1, in I2, in I3, in I4, out O>
    {
        O Execute(I1 imput1, I2 imput2, I3 imput3, I4 imput4);
    }
}
