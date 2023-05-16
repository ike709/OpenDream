using CommunityToolkit.Diagnostics;
using OpenDreamRuntime.Procs;

namespace OpenDreamRuntime.Objects.MetaObjects {
    public interface IDreamMetaObject {
        public bool ShouldCallNew { get; }
        public IDreamMetaObject? ParentType { get; set; }

        public void OnObjectCreated(DreamObject dreamObject, DreamProcArguments creationArguments) =>
            ParentType?.OnObjectCreated(dreamObject, creationArguments);

        public void OnObjectDeleted(DreamObject dreamObject) =>
            ParentType?.OnObjectDeleted(dreamObject);

        public void OnVariableSet(DreamObject dreamObject, string varName, DreamValue value, DreamValue oldValue) =>
            ParentType?.OnVariableSet(dreamObject, varName, value, oldValue);

        public DreamValue OnVariableGet(DreamObject dreamObject, string varName, DreamValue value) =>
            ParentType?.OnVariableGet(dreamObject, varName, value) ?? value;

        public void OperatorOutput(DreamObject a, DreamValue b) {
            Guard.IsNotNull(ParentType);

            ParentType.OperatorOutput(a, b);
        }

        public DreamValue OperatorAdd(DreamValue a, DreamValue b) {
            Guard.IsNotNull(ParentType);

            return ParentType.OperatorAdd(a, b);
        }

        public DreamValue OperatorSubtract(DreamValue a, DreamValue b) {
            Guard.IsNotNull(ParentType);

            return ParentType.OperatorSubtract(a, b);
        }

        public DreamValue OperatorMultiply(DreamValue a, DreamValue b) {
            Guard.IsNotNull(ParentType);

            return ParentType.OperatorMultiply(a, b);
        }

        public DreamValue OperatorAppend(DreamValue a, DreamValue b) {
            Guard.IsNotNull(ParentType);

            return ParentType.OperatorAppend(a, b);
        }

        public DreamValue OperatorRemove(DreamValue a, DreamValue b) {
            Guard.IsNotNull(ParentType);

            return ParentType.OperatorRemove(a, b);
        }

        public DreamValue OperatorOr(DreamValue a, DreamValue b) {
            Guard.IsNotNull(ParentType);

            return ParentType.OperatorOr(a, b);
        }

        public DreamValue OperatorEquivalent(DreamValue a, DreamValue b) {
            if (ParentType == null)
                return a.Equals(b) ? new DreamValue(1f) : new DreamValue(0f);

            return ParentType.OperatorEquivalent(a, b);
        }

        public DreamValue OperatorCombine(DreamValue a, DreamValue b) {
            Guard.IsNotNull(ParentType);

            return ParentType.OperatorCombine(a, b);
        }

        public DreamValue OperatorMask(DreamValue a, DreamValue b) {
            Guard.IsNotNull(ParentType);

            return ParentType.OperatorMask(a, b);
        }

        public DreamValue OperatorIndex(DreamObject dreamObject, DreamValue index) {
            Guard.IsNotNull(ParentType);

            return ParentType.OperatorIndex(dreamObject, index);
        }

        public void OperatorIndexAssign(DreamObject dreamObject, DreamValue index, DreamValue value) {
            Guard.IsNotNull(ParentType);

            ParentType.OperatorIndexAssign(dreamObject, index, value);
        }
    }
}
