import { mapState } from "vuex";

export default (await import("vue")).defineComponent({
  name: "App",
  components: { Header, Content, Footer },
  computed: mapState(["isTemplateVisible", "user"]),
  data: function () {
    return {};
  },
  methods: {},
  created() {},
});
