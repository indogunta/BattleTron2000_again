//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Linq;
//using System.Reflection;
//using UnityEditor;
//using UnityEngine;
//using UnityEngine.SceneManagement;


//public class ScanBotEditorWindow : EditorWindow
//{
//    private string scannedName = "";
//     private string scannedMember = "";
//    [MenuItem("Tools/Observer %`")]
//    public static void CreateScanBot()
//    {
//        GetWindow<ScanBotEditorWindow>(false, "ScannerBot", false);

            
//    }

//    public void OnGUI()
//    {

//        scannedName = EditorGUILayout.TextField("Scan", scannedName);
//        scannedMember = EditorGUILayout.TextField("Scan", scannedMember);

//        EditorGUILayout.TextField("");
//        if (!string.IsNullOrEmpty(scannedName))
//        {
//                var gameobbys =  Resources.FindObjectsOfTypeAll<GameObject>()
//                     .Where(obbys => obbys.scene.isLoaded)
//                     .Where(obbys => obbys.name.Contains(scannedName));
//                            foreach (var obbys in gameobbys)
//            {
//                var component = obbys.GetComponent<Transform>();
//                 var info =     GetMemberByName(component, scannedMember);


//                if (info != null)
//                {
//                    if(Getmem.IsDefined(typeof(Vector3), true))
//                    {
//                       SetVelueofMember<Vector3>(EditorGUILayout.Vector3Field(obbys.name, GetValueOfMember<Vector3>(info, component)), component);
//                    }               
//                }
//            }

//        }
//        else
//                     {
//                                  EditorGUILayout.HelpBox("No Object by that name!!!", MessageType.Warning);
//                     }
//    }


//    private Type GetMemberType<T>(MemberInfo info, T input, object source)
//    {
//        switch (info.MemberType)
//        {
//            case MemberTypes.Field:
//           return     ((FieldInfo)info).FieldType;

          
//            case MemberTypes.Property:
//             return   ((PropertyInfo)info).PropertyType;
              
//            default:
//                return null;
//        }
//    }
//    private void SetVelueofMember<T>(MemberInfo info, T  input, object source)
//    {
//        switch (info.MemberType)
//        {
//            case MemberTypes.Field:
//               ((FieldInfo)info).SetValue(source, input);
//                break;
//            case MemberTypes.Property:
//               ((PropertyInfo)info).SetValue(source, input,null);
//                break;
//            default:
//                break;
//        }
//    }



//    private T GetValueOfMember<T>(MemberInfo info, object source)
//    {
//        switch (info.MemberType)
//        {
//            case MemberTypes.Field:
//                return (T)((FieldInfo)info).GetValue(source);
//            case MemberTypes.Property:
//                return (T)((PropertyInfo)info).GetValue(source, null);
//            default:
//                return default(T)  ;
//        }
//    }



//    private MemberInfo GetMemberByName(Component component, string scannedMember)
//    {
//        MemberInfo info =  component.GetType().GetField(scannedMember);
//        if (info == null)
//        {
//            info = component.GetType().GetField(scannedMember);
//        }
//        return info;

//    }


//}
