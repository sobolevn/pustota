<template>
  <div>
</template>

<script lang="ts">
import { Component, mixins } from 'nuxt-property-decorator'
import { Store } from 'vuex'
import { useStore } from 'vuex-simple'

import ActionBar from '~/components/ActionBar.vue'
import AppLogo from '~/components/AppLogo.vue'
import Comment from '~/components/Comment.vue'
import { RawCommentType } from '~/logic/comments/models'
import TypedStore from '~/logic/store'
import { StateType } from '~/logic/types'
import TypedStoreMixin from '~/mixins/typed-store'
</script>
