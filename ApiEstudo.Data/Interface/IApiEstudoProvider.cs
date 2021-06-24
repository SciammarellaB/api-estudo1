using ApiEstudo.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiEstudo.Data.Interface
{
    public interface IApiEstudoProvider
    {
        SessionAppModel SessionApp { get; }
    }
}
