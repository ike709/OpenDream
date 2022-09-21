using OpenDreamRuntime.Procs;
using OpenDreamShared.Dream;
//using Robust.Client.Graphics;

namespace OpenDreamRuntime.Objects.MetaObjects {
    sealed class DreamMetaObjectFilter : IDreamMetaObject {
        public bool ShouldCallNew => false;
        public IDreamMetaObject? ParentType { get; set; }

        public void OnVariableSet(DreamObject dreamObject, string varName, DreamValue value, DreamValue oldValue) {
            //recompile shader
        }
        /*private ShaderInstance MakeNewShader(Dictionary<string,DreamValue> parameters)
        {
            DreamValue shaderName;
            if(!parameters.TryGetValue("type", out shaderName))
                throw new Exception("attempt to make a shader without a name");

            var instance = _prototypeManager.Index<ShaderPrototype>(shaderName).InstanceUnique();
            instance.SetParameter("outline_width", DefaultWidth * renderScale);
            return instance;
        } */
    }
}