namespace MM.Shared.Enums
{
    public enum Food
    {
        [Custom(Name = "Asian Cuisine", Description = "A diverse range of flavors from East and Southeast Asia, featuring rice and noodle dishes (e.g., Sushi (Japan), Pho (Vietnam), Pad Thai (Thailand), Dumplings (China), Ramen (Japan), Satay (Indonesia)).")]
        AsianCuisine = 1,

        [Custom(Name = "European Cuisine", Description = "Traditional and modern dishes from various European countries, emphasizing fresh ingredients and unique cooking styles (e.g., Pasta (Italy), Ratatouille (France), Paella (Spain), Sauerbraten (Germany), Borscht (Ukraine), Fish and Chips (United Kingdom)).")]
        EuropeanCuisine = 2,

        [Custom(Name = "Middle Eastern & North African", Description = "Rich and aromatic dishes characterized by spices and herbs, often featuring grilled meats and hearty grains (e.g., Shawarma (Lebanon), Couscous (Morocco), Tagine (Algeria), Hummus (Israel), Falafel (Egypt), Kebabs (Turkey)).")]
        MiddleEasternNorthAfrican = 3,

        [Custom(Name = "Latin American", Description = "Vibrant and flavorful foods reflecting the diverse cultures of Central and South America (e.g., Tacos (Mexico), Empanadas (Argentina), Feijoada (Brazil), Arepas (Venezuela), Ceviche (Peru), Tamales (Mexico)).")]
        LatinAmerican = 4,

        [Custom(Name = "African Cuisine", Description = "Varied dishes focusing on stews, grains, and root vegetables, often seasoned with unique local spices (e.g., Jollof Rice (Nigeria), Injera (Ethiopia), Bobotie (South Africa), Tagine (Morocco), Biltong (South Africa), Fufu (Ghana)).")]
        AfricanCuisine = 5,

        [Custom(Name = "Indian & South Asian", Description = "Spicy and flavorful dishes, often centered around rice and bread, using a variety of spices (e.g., Biryani (India), Daal (Pakistan), Curry (Bangladesh), Samosas (India), Butter Chicken (India), Chaat (India)).")]
        IndianSouthAsian = 6,

        [Custom(Name = "North American", Description = "Comfort foods with a focus on hearty meals, BBQ, and regional specialties (e.g., Burgers (United States), Poutine (Canada), Clam Chowder (United States), BBQ Ribs (United States), Jambalaya (United States), Cornbread (United States)).")]
        NorthAmerican = 7,

        [Custom(Name = "Mediterranean", Description = "Light and healthy meals, typically featuring fresh vegetables, grains, and grilled proteins (e.g., Greek Salad (Greece), Hummus (Lebanon), Falafel (Egypt), Tabbouleh (Lebanon), Fattoush (Lebanon), Grilled Octopus (Greece)).")]
        Mediterranean = 8,

        [Custom(Name = "Seafood", Description = "Dishes focusing on fish and shellfish, celebrated for their freshness and variety (e.g., Ceviche (Peru), Fish Tacos (Mexico), Grilled Salmon (Norway), Lobster Roll (United States), Clam Chowder (United States), Bouillabaisse (France)).")]
        Seafood = 9,

        [Custom(Name = "Vegetarian", Description = "A wide array of plant-based meals, highlighting vegetables, legumes, and grains (e.g., Ratatouille (France), Vegetable Stir-fry (China), Stuffed Peppers (Italy), Caprese Salad (Italy), Lentil Soup (Turkey), Veggie Burger (United States)).")]
        Vegetarian = 10,

        [Custom(Name = "Vegan", Description = "Completely plant-based meals without any animal products, often creative and flavorful (e.g., Vegan Burgers (United States), Tofu Stir-fry (Thailand), Chickpea Salad (Global), Vegan Chili (United States), Vegan Sushi (Japan), Quinoa Salad (Peru)).")]
        Vegan = 11,

        [Custom(Name = "Street Food", Description = "Casual, flavorful foods that are often sold by vendors and reflect local tastes (e.g., Pani Puri (India), Hot Dogs (United States), Arepas (Venezuela), Churros (Spain), Gyoza (Japan), Spring Rolls (Vietnam)).")]
        StreetFood = 12,

        [Custom(Name = "Fast Food & Comfort", Description = "Quick meals that are typically easy to prepare and satisfy cravings (e.g., Fried Chicken (United States), Pizza (Italy), Fish and Chips (United Kingdom), Nachos (Mexico), Doner Kebab (Turkey), Cheeseburger (United States)).")]
        FastFoodComfort = 13,

        [Custom(Name = "Fusion Cuisine", Description = "Innovative dishes that blend ingredients and cooking techniques from different cultures (e.g., Korean Tacos (United States), Sushi Burritos (United States), Indian Pizza (India), Thai Curry Pizza (United States), Mediterranean Burrito (Global), Banh Mi Burger (Vietnam)).")]
        FusionCuisine = 14,

        [Custom(Name = "Desserts & Sweets", Description = "A variety of sweet treats and desserts, showcasing flavors and techniques from around the world (e.g., Tiramisu (Italy), Baklava (Turkey), Mochi (Japan), Crème Brûlée (France), Churros (Spain), Dulce de Leche (Argentina)).")]
        DessertsSweets = 15,

        [Custom(Name = "Spicy Food", Description = "Dishes known for their heat and robust flavors, appealing to those who enjoy bold tastes (e.g., Spicy Ramen (Japan), Sichuan Hot Pot (China), Spicy Curry (India), Vindaloo (India), Spicy Tacos (Mexico), Kimchi (Korea)).")]
        SpicyFood = 16,

        [Custom(Name = "Savory Snacks & Small Plates", Description = "Small, flavorful bites that are perfect for sharing or as appetizers (e.g., Tapas (Spain), Dim Sum (China), Mezze Platter (Middle East), Charcuterie Board (France), Antipasto (Italy), Samosas (India)).")]
        SavorySnacksSmallPlates = 17,

        [Custom(Name = "Home-Cooked Traditional", Description = "Family-style meals that reflect cultural heritage and comfort, often made with love (e.g., Roast Chicken (United States), Lasagna (Italy), Curry (India), Borscht (Ukraine), Meatloaf (United States), Goulash (Hungary)).")]
        HomeCookedTraditional = 18,

        [Custom(Name = "Grilled & Barbecue", Description = "Dishes that are cooked over an open flame or grill, celebrated for their smoky flavors (e.g., BBQ Ribs (United States), Tandoori Chicken (India), Grilled Fish (Global), Satay (Indonesia), Grilled Vegetables (Mediterranean), Charcoal-Grilled Meat (Korea)).")]
        GrilledBarbecue = 19,

        [Custom(Name = "Baked Goods", Description = "A wide range of breads, pastries, and sweets that are enjoyed as snacks or desserts (e.g., Croissants (France), Bagels (United States), Scones (United Kingdom), Danish Pastry (Denmark), Brownies (United States), Puff Pastry (France)).")]
        BakedGoods = 20,
    }
}