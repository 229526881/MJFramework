﻿namespace NPBehave
{

    public abstract class Decorator : Container
    {
        protected Node Decoratee;

        protected Decorator(string name) : base(name)
        {
        }

        protected Decorator(string name, Node decoratee) : base(name)
        {
            this.Decoratee = decoratee;
            this.Decoratee.SetParent(this);
        }

        public override void SetRoot(Root rootNode)
        {
            base.SetRoot(rootNode);
            Decoratee.SetRoot(rootNode);
        }

        public virtual void Init(Node decoratee)
        {
            base.Init();
            this.Decoratee = decoratee;
            this.Decoratee.SetParent(this);
        }

        public override void Dispose()
        {
            this.Decoratee.Dispose();
            this.Decoratee = null;
            base.Dispose();
        }


#if UNITY_EDITOR
        public override Node[] DebugChildren
        {
            get
            {
                return new Node[] { Decoratee };
            }
        }
#endif

        public override void ParentCompositeStopped(Composite composite)
        {
            base.ParentCompositeStopped(composite);
            Decoratee.ParentCompositeStopped(composite);
        }
    }
}