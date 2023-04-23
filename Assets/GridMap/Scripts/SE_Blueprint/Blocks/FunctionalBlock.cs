using System.Xml.Serialization;

[
    XmlInclude(typeof(InteriorLight)),
    XmlInclude(typeof(DoorBlock)),
    XmlInclude(typeof(InventoryBlock)),
    XmlInclude(typeof(Airvent))
]
public class FunctionalBlock : CubeBlock
{
    public long Owner;
    public string DisplayName;
    [XmlElement("ShareMode")]
    public ShareModeEnum ShareMode;
    public bool ShowOnHUD;
    public bool ShowInTerminal;
    public bool ShowInToolbarConfig;
    public bool ShowInInventory;
    public long NumberInGrid;
    public bool Enabled;
}
[
    XmlInclude(typeof(Sorter))
]
public class InventoryBlock : FunctionalBlock {}