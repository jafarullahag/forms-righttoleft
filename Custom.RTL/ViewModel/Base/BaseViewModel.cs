using System;
using Custom.RTL.Common;
using Xamarin.Forms;
using static Custom.RTL.Common.GlobalEnum;

namespace Custom.RTL.ViewModel.Base
{
    public class BaseViewModel : NotifyPropertyChanged
    {
        static BaseViewModel()
        {
            if (LangResourceLoader.Instance.CurrentLanguageAbbr == LanguageCode.Arabic)
            {
                _flowDirection = FlowDirection.RightToLeft;
            }
            else
            {
                _flowDirection = FlowDirection.LeftToRight;
            }
        }

        public BaseViewModel()
        {
            Language.PropertyChanged += (sender, e) =>
            {
                if (Language.CurrentLanguageAbbr == LanguageCode.Arabic)
                {
                    FlowDirection = FlowDirection.RightToLeft;
                }
                else
                {
                    FlowDirection = FlowDirection.LeftToRight;
                }
            };
        }

        private Page _page;
        public Page Page
        {
            get
            {
                return _page;
            }
        }

        public LangResourceLoader Language
        {
            get
            {
                return LangResourceLoader.Instance;
            }
        }

        private static FlowDirection _flowDirection = Device.FlowDirection;
        public FlowDirection FlowDirection
        {
            get
            {
                return _flowDirection;
            }
            set
            {
                _flowDirection = value;
                if (_page != null)
                {
                    _page.FlowDirection = _flowDirection;
                }
                OnPropertyChanged("FlowDirection");
            }
        }

        VisualElement _visualElement;
        public VisualElement VisualElement
        {
            get
            {
                return _visualElement;
            }
            set
            {
                if (_visualElement != value && value != null)
                {
                    _visualElement = value;
                    var p = Page;

                    if (_visualElement is Page page)
                    {
                        _page = page;
                    }

                    if (_visualElement.BindingContext == null)
                    {
                        _visualElement.BindingContext = this;
                    }

                    if (_page != null)
                    {
                        _page.FlowDirection = FlowDirection;
                    }

                    OnPropertyChanged("VisualElement");
                }
            }
        }
    }
}
