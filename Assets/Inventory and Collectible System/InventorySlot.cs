using UnityEngine;
using UnityEngine.UIElements;

public class InventorySlot : VisualElement
{
    public Image Icon;
    public string ItemGuid = "";

    public InventorySlot()
    {
        // creates a new Image element and adds it as a child to the root of this custom element
        Icon = new Image();
        Add(Icon);

        // Add USS classes to the elements for styling  
        Icon.AddToClassList("slotIcon");
        AddToClassList("slotContainer");
    }
}
