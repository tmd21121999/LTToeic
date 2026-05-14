window.QuillHelpers = {
    getEditorHTML: function (wrapperId) {
        var container = document.querySelector('#' + wrapperId + ' .ql-container');
        return (container && container.__quill) ? container.__quill.root.innerHTML : '';
    },
    setEditorHTML: function (wrapperId, html) {
        var container = document.querySelector('#' + wrapperId + ' .ql-container');
        if (container && container.__quill) {
            var delta = container.__quill.clipboard.convert(html || '');
            container.__quill.setContents(delta, 'silent');
        }
    }
};
