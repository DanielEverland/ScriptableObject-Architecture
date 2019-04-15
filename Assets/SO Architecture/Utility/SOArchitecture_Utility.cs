namespace ScriptableObjectArchitecture
{
    public static class SOArchitecture_Utility
    {
        public const int ASSET_MENU_ORDER_VARIABLES = 121;
        public const int ASSET_MENU_ORDER_EVENTS = 122;
        public const int ASSET_MENU_ORDER_COLLECTIONS = 123;
        public const int ASSET_MENU_ORDER_CLAMPED_VARIABLES = 122;

        public const string VARIABLE_SUBMENU = "Variables/";
        public const string VARIABLE_CLAMPED_SUBMENU = VARIABLE_SUBMENU + "Clamped/";
        public const string COLLECTION_SUBMENU = "Collections/";
        public const string GAME_EVENT = "Game Events/";

        public const string ADVANCED_GAME_EVENT = GAME_EVENT + "Advanced/";
        public const string ADVANCED_VARIABLE_SUBMENU = VARIABLE_SUBMENU + "Advanced/";
        public const string ADVANCED_VARIABLE_COLLECTION = COLLECTION_SUBMENU + "Advanced/";
    } 
}