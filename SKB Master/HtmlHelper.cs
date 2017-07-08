using System.Windows.Forms;

namespace SKB_Master {
    public static class HtmlHelper {
        public static HtmlElement GetDescendantElement( HtmlElement ancestorElement, string descendantElementTagName, string descendantElementClassName = null ) {
            if ( ancestorElement != null ) {
                HtmlElementCollection elements = ancestorElement.GetElementsByTagName( descendantElementTagName );
                foreach ( HtmlElement element in elements ) {
                    if ( descendantElementClassName == null ) {
                        return element;
                    } else {
                        string className = element.GetAttribute( "className" );
                        if ( className == descendantElementClassName ) {
                            return element;
                        }
                    }
                }
            }
            return null;
        }

        public static HtmlElement GetDescendantElement( HtmlElementCollection ancestorElementCollection, string descendantElementTagName, string descendantElementClassName = null ) {
            if ( ancestorElementCollection != null ) {
                foreach ( HtmlElement rootElement in ancestorElementCollection ) {
                    if ( rootElement.TagName == descendantElementTagName ) {
                        if ( descendantElementClassName == null ) {
                            return rootElement;
                        } else {
                            string className = rootElement.GetAttribute( "className" );
                            if ( className == descendantElementClassName ) {
                                return rootElement;
                            }
                        }
                    } else {
                        HtmlElement descendantElement = GetDescendantElement( rootElement, descendantElementTagName, descendantElementClassName );
                        if ( descendantElement != null ) {
                            return descendantElement;
                        }
                    }
                }
            }
            return null;
        }
    }
}
