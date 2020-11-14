using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;

using System;
using System.Collections.Generic;
using System.Linq;

namespace OriinDic.Components
{
    public partial class RedirectToLogin : ComponentBase
    {
        [Inject]
        protected NavigationManager? NavigationManager { get; set; }

        protected override void OnInitialized()
        {
            NavigationManager?.NavigateTo("login");
        }
    }
}
