using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleFileBrowser;
using System.IO;
using System.Xml;

public static class Blueprint
{

    private static string blueprintsDirectory(){
        return string.Join(Path.DirectorySeparatorChar,
        new List<string>(){
            "%AppData%","Roeaming","SpaceEngineers","Blueprints","local"
        });
    }

    private static DirectoryInfo createAndGetBlueprintDirectory(){
        if(Directory.Exists("%AppData%"+Path.DirectorySeparatorChar+"Roaming"+Path.DirectorySeparatorChar+"SpaceEngineers")){
            return Directory.CreateDirectory(blueprintsDirectory());
        }
        return null;
    }


    public static void LoadDialog(){
        DirectoryInfo blueprints = createAndGetBlueprintDirectory();
        FileBrowser.SetFilters(false,new [] {".sbc"});
        if(blueprints != null && blueprints.Exists){
            FileBrowser.ShowLoadDialog( load, () => {}, FileBrowser.PickMode.Files, false, blueprintsDirectory(), null, "Select Blueprint" );
        } else {
            FileBrowser.ShowLoadDialog( load, () => {}, FileBrowser.PickMode.Files, false, null, null, "Select Blueprint" );
        }
    }

    private static void load( string[] paths ){
        if("bp.sbc".Equals(Path.GetFileName(paths[0]))) {
            ShipBlueprint blueprint = ShipBlueprint.Load(paths[0]);
            UnityEngine.GameObject.Find("ShipEditor").GetComponent<ShipManager>().SetShipBlueprint(blueprint);
        }
    }

    private static void save( string path, ShipBlueprint blueprint ){
            blueprint.Save(Path.Join(Path.GetDirectoryName(path),"bp.sbc"));
    }
}
