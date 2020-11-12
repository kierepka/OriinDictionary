﻿using Microsoft.AspNetCore.Components;

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
