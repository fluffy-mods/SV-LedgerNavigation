using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewValley;
using StardewValley.Menus;

namespace Fluffy.LedgerNavigation {
    public class ModEntry: Mod {

        public override void Entry(IModHelper helper) {
            helper.Events.Specialized.UnvalidatedUpdateTicked += HandleLedgerNavigation;
        }

        private void HandleLedgerNavigation(object sender, UnvalidatedUpdateTickedEventArgs e) {
            if (Game1.activeClickableMenu is ShippingMenu shippingMenu && shippingMenu.currentPage != -1) {
                if (Helper.Input.IsDown(SButton.Escape) || Helper.Input.IsDown(SButton.Left)) {
                    // back/left arrow
                    shippingMenu.receiveLeftClick(shippingMenu.backButton.bounds.Center.X, shippingMenu.backButton.bounds.Center.Y);

                } else if (shippingMenu.showForwardButton() && Helper.Input.IsDown(SButton.Right)) {
                    // forward/right arrow
                    shippingMenu.receiveLeftClick(shippingMenu.forwardButton.bounds.Center.X, shippingMenu.forwardButton.bounds.Center.Y);
                }
            }
        }
    }
}
